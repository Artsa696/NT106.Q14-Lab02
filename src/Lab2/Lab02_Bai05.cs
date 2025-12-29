using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Lab02_Bai05 : Form
    {
        private string inputFile = "input5.txt";
        private string outputFile = "output5.txt";

        private List<MovieRoom> movies = new List<MovieRoom>();

        public Lab02_Bai05()
        {
            InitializeComponent();
        }

        private void btnReadInput_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(inputFile))
                {
                    MessageBox.Show($"Không tìm thấy file '{inputFile}'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var lines = File.ReadAllLines(inputFile).Select(l => l.Trim()).Where(l => !string.IsNullOrEmpty(l)).ToArray();
                rtbInputDisplay.Text = string.Join(Environment.NewLine, lines);
                MessageBox.Show($"Đã đọc {lines.Length} dòng từ '{inputFile}'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đọc file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnShowOutput_Click(object sender, EventArgs e)
        {
            try
            {
                movies.Clear();
                var inputLines = rtbInputDisplay.Text
                    .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(l => l.Trim())
                    .Where(l => l != "")
                    .ToArray();

                if (inputLines.Length < 5 || inputLines.Length % 5 != 0)
                {
                    MessageBox.Show("Định dạng input không hợp lệ. Vui lòng dùng 5 dòng/phim: tên, giá, phòng, sức chứa, vé đã bán.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int movieCount = inputLines.Length / 5;
                var parseErrors = new List<string>();
                for (int i = 0; i < movieCount; i++)
                {
                    var name = inputLines[i * 5 + 0];
                    var priceText = inputLines[i * 5 + 1];
                    var room = inputLines[i * 5 + 2];
                    var capText = inputLines[i * 5 + 3];
                    var soldText = inputLines[i * 5 + 4];

                    if (!decimal.TryParse(priceText, out decimal price)) parseErrors.Add($"Phim '{name}': Giá ('{priceText}') không hợp lệ.");
                    if (!int.TryParse(capText, out int capacity)) parseErrors.Add($"Phim '{name}': Sức chứa ('{capText}') không hợp lệ.");
                    if (!int.TryParse(soldText, out int sold)) parseErrors.Add($"Phim '{name}': Số vé bán ('{soldText}') không hợp lệ.");

                    if (parseErrors.Count == 0)
                    {
                        movies.Add(new MovieRoom { Name = name, Price = price, Room = room, Capacity = capacity, Sold = sold });
                    }
                }

                if (parseErrors.Count > 0)
                {
                    var msg = new StringBuilder();
                    msg.AppendLine("Lỗi khi phân tích input:");
                    foreach (var err in parseErrors.Take(30)) msg.AppendLine("- " + err);
                    MessageBox.Show(msg.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var stats = movies.Select(m => new MovieStat
                {
                    Name = m.Name,
                    Sold = m.Sold,
                    Remaining = Math.Max(0, m.Capacity - m.Sold),
                    Rate = m.Capacity > 0 ? (double)m.Sold * 100.0 / m.Capacity : 0.0,
                    Revenue = m.Price * m.Sold
                }).OrderByDescending(s => s.Revenue).ToList();

                var sb = new StringBuilder();
                sb.AppendLine("Rank | Tên phim | Số vé bán | Số vé tồn | Tỉ lệ bán (%) | Doanh thu");

                progressBar.Minimum = 0;
                progressBar.Maximum = stats.Count;
                progressBar.Value = 0;

                for (int i = 0; i < stats.Count; i++)
                {
                    var s = stats[i];
                    int rank = i + 1;
                    sb.AppendLine($"{rank} | {s.Name} | {s.Sold} | {s.Remaining} | {s.Rate:F2} | {s.Revenue:F0}");

                    await Task.Delay(50);
                    progressBar.Value = i + 1;
                }

                File.WriteAllText(outputFile, sb.ToString(), Encoding.UTF8);
                lblStatus.Text = $"Đã xuất {stats.Count} phim vào '{outputFile}'.";

                // show output
                var dlg = new Form();
                dlg.Text = "output5.txt";
                dlg.ClientSize = new Size(800, 400);
                var rtb = new RichTextBox { Dock = DockStyle.Fill, ReadOnly = true, Text = sb.ToString() };
                dlg.Controls.Add(rtb);
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                try { progressBar.Value = 0; } catch { }
            }
        }

        private class MovieRoom
        {
            public string Name { get; set; } = string.Empty;
            public decimal Price { get; set; }
            public string Room { get; set; } = string.Empty;
            public int Sold { get; set; }
            public int Capacity { get; set; }
        }

        private class MovieStat
        {
            public string Name { get; set; } = string.Empty;
            public int Sold { get; set; }
            public int Remaining { get; set; }
            public double Rate { get; set; }
            public decimal Revenue { get; set; }
        }
    }
}
