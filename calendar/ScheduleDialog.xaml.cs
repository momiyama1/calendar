using System.Windows;

namespace CalendarApp
{
    public partial class ScheduleDialog : Window
    {
        public string Schedule { get; private set; }

        // コンストラクタで既存の予定を設定
        public ScheduleDialog(string existingSchedule)
        {
            InitializeComponent();
            ScheduleTextBox.Text = existingSchedule;
            Schedule = existingSchedule;
        }

        // 保存ボタンのクリック処理
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Schedule = ScheduleTextBox.Text; // テキストボックスの内容を取得
            DialogResult = true; // ダイアログを閉じて、保存したことを伝える
        }

        // 削除ボタンのクリック処理
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Schedule = string.Empty; // 予定を削除
            ScheduleTextBox.Clear(); // テキストボックスをクリア
            DialogResult = true; // ダイアログを閉じて、削除を伝える
        }

        // キャンセルボタンのクリック処理
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false; // ダイアログを閉じる
        }
    }
}
