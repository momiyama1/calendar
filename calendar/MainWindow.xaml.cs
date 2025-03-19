using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CalendarApp
{
    public partial class MainWindow : Window
    {
        private DateTime currentDate = DateTime.Today;
        private Dictionary<string, string> scheduleData = new Dictionary<string, string>();
        private const string ScheduleFilePath = "schedule.json";

        public MainWindow()
        {
            InitializeComponent();
            LoadSchedule();
            GenerateCalendar();
        }

        // カレンダーを生成するメソッド
        private void GenerateCalendar()
        {
            int daysInMonth = DateTime.DaysInMonth(currentDate.Year, currentDate.Month);
            DateTime firstDayOfMonth = new DateTime(currentDate.Year, currentDate.Month, 1);

            // 月表示を更新
            MonthText.Text = $"{currentDate:yyyy年MM月}";

            // 日付ボタンを動的に追加
            DayGrid.Children.Clear(); // 前回のカレンダーをクリア

            // 曜日ラベルを追加
            string[] weekdays = { "日", "月", "火", "水", "木", "金", "土" };
            for (int i = 0; i < weekdays.Length; i++)
            {
                TextBlock textBlock = new TextBlock()
                {
                    Text = weekdays[i],
                    FontSize = 18,
                    FontWeight = FontWeights.Bold,
                    TextAlignment = TextAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };
                Grid.SetRow(textBlock, 0);
                Grid.SetColumn(textBlock, i);
                DayGrid.Children.Add(textBlock);
            }

            // 空白を挿入（週の開始日まで）
            int startDay = (int)firstDayOfMonth.DayOfWeek;
            int row = 1, col = startDay;

            // 日付をボタンとして追加
            for (int day = 1; day <= daysInMonth; day++)
            {
                Button dayButton = new Button()
                {
                    Content = day.ToString(), // ボタンに日付を表示
                };

                // 日付キーを作成
                string dateKey = new DateTime(currentDate.Year, currentDate.Month, day).ToString("yyyy-MM-dd");

                // 今日の日付か判定し、スタイルを変更
                if (currentDate.Year == DateTime.Today.Year && currentDate.Month == DateTime.Today.Month && day == DateTime.Today.Day)
                {
                    dayButton.BorderBrush = Brushes.Blue; // 枠線の色を変更
                    dayButton.BorderThickness = new Thickness(2); // 枠線の太さを変更
                }

                // 予定がある場合、ボタンの色を変え、予定を表示
                if (scheduleData.ContainsKey(dateKey))
                {
                    dayButton.Background = Brushes.Yellow; // 予定ありのボタンは黄色にする
                    dayButton.ToolTip = scheduleData[dateKey]; // ツールチップで予定を表示
                    dayButton.Content = $"{day}\n{scheduleData[dateKey]}"; // ボタン内に予定を表示
                }

                dayButton.Click += DayButton_Click; // 日付ボタンのクリックイベントを追加

                // Grid に配置
                Grid.SetRow(dayButton, row);
                Grid.SetColumn(dayButton, col);
                DayGrid.Children.Add(dayButton);

                // カラムを進める
                col++;
                if (col > 6)
                {
                    col = 0;
                    row++;
                }
            }
        }

        private void DayButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button clickedButton)
            {
                // ボタンのContentから日付の部分だけを取得
                string dayText = clickedButton.Content as string ?? "";

                // 日付と予定がある場合は、日付部分だけを抽出
                string[] parts = dayText.Split('\n');
                string dayString = parts[0];  // 最初の部分が日付

                // 日付として解析
                if (int.TryParse(dayString, out int dayInt))
                {
                    string dateKey = new DateTime(currentDate.Year, currentDate.Month, dayInt).ToString("yyyy-MM-dd");
                    string existingSchedule = scheduleData.ContainsKey(dateKey) ? scheduleData[dateKey] : "";

                    // 新しく作成したダイアログを表示
                    ScheduleDialog scheduleDialog = new ScheduleDialog(existingSchedule);

                    bool? result = scheduleDialog.ShowDialog(); // ダイアログを表示

                    if (result == true)
                    {
                        string newSchedule = scheduleDialog.Schedule;

                        if (!string.IsNullOrWhiteSpace(newSchedule))
                        {
                            scheduleData[dateKey] = newSchedule; // 予定を保存
                        }
                        else
                        {
                            if (scheduleData.ContainsKey(dateKey))
                            {
                                scheduleData.Remove(dateKey); // 予定を削除
                            }
                        }

                        SaveSchedule(); // 変更を保存

                        // カレンダーを再生成してボタン表示を更新
                        GenerateCalendar();
                    }
                }
                else
                {
                    MessageBox.Show("無効な日付が選択されました。");
                }
            }
        }


        private void PreviousMonth_Click(object sender, RoutedEventArgs e)
        {
            currentDate = currentDate.AddMonths(-1);
            GenerateCalendar();
        }

        private void NextMonth_Click(object sender, RoutedEventArgs e)
        {
            currentDate = currentDate.AddMonths(1);
            GenerateCalendar();
        }

        // 予定をJSONファイルに保存する
        private void SaveSchedule()
        {
            try
            {
                string json = JsonSerializer.Serialize(scheduleData, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(ScheduleFilePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"予定の保存に失敗しました: {ex.Message}");
            }
        }

        // JSONファイルから予定を読み込む
        private void LoadSchedule()
        {
            try
            {
                if (File.Exists(ScheduleFilePath))
                {
                    string json = File.ReadAllText(ScheduleFilePath);
                    scheduleData = JsonSerializer.Deserialize<Dictionary<string, string>>(json) ?? new Dictionary<string, string>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"予定の読み込みに失敗しました: {ex.Message}");
            }
        }
    }
}