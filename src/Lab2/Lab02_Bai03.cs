using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Lab2
{
    public partial class Lab02_Bai03 : Form
    {
        public Lab02_Bai03()
        {
            InitializeComponent();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            // Let user pick input file
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                ofd.FileName = "input3.txt";
                ofd.Title = "Chọn file input";

                if (ofd.ShowDialog() != DialogResult.OK)
                {
                    return; // user cancelled
                }

                string inputFile = ofd.FileName;

                // Let user pick output file
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                    sfd.FileName = "output3.txt";
                    sfd.Title = "Chọn file output";

                    if (sfd.ShowDialog() != DialogResult.OK)
                    {
                        return; // user cancelled
                    }

                    string outputFile = sfd.FileName;

                    try
                    {
                        string[] lines = File.ReadAllLines(inputFile);
                        List<string> outputLines = new List<string>();

                        foreach (string line in lines)
                        {
                            if (string.IsNullOrWhiteSpace(line)) continue;

                            try
                            {
                                double result = TinhToan(line);
                                // display with '*' replaced by '.' as requested
                                var displayExpr = line.Replace('*', '.'); 
                                string outLine = displayExpr + " = " + result.ToString();
                                outputLines.Add(outLine);
                            }
                            catch (Exception)
                            {
                                outputLines.Add(line + " = Error");
                            }
                        }

                        File.WriteAllLines(outputFile, outputLines);
                        rtbResult.Text = string.Join(Environment.NewLine, outputLines);
                        MessageBox.Show($"Đã xử lý và ghi ra file '{Path.GetFileName(outputFile)}' thành công!");
                    }
                    catch (FileNotFoundException)
                    {
                        MessageBox.Show("Lỗi: Không tìm thấy file input.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Hàm tự viết để tính toán biểu thức (hỗ trợ +, -, *, / và ngoặc)
        /// Sử dụng thuật toán shunting-yard để chuyển về RPN rồi tính.
        /// </summary>
        private double TinhToan(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression)) return 0;

            List<string> tokens = Tokenize(expression);
            List<string> rpn = ToRpn(tokens);
            double result = EvalRpn(rpn);
            return result;
        }

        private List<string> Tokenize(string expr)
        {
            var tokens = new List<string>();
            var number = new StringBuilder();
            bool expectUnary = true;

            int i = 0;
            while (i < expr.Length)
            {
                char c = expr[i];
                if (char.IsWhiteSpace(c)) { i++; continue; }

                if (expectUnary && (c == '+' || c == '-'))
                {
                    // lookahead to see if next non-space is '(' -> treat as 0 <op> ( ... )
                    int j = i + 1;
                    while (j < expr.Length && char.IsWhiteSpace(expr[j])) j++;
                    if (j < expr.Length && expr[j] == '(')
                    {
                        // unary before parenthesis: insert 0 then operator
                        tokens.Add("0");
                        tokens.Add(c.ToString());
                        i++; // consume sign
                        expectUnary = true; // still can have unary after operator
                        continue;
                    }

                    // otherwise parse signed number if digits follow
                    int k = i + 1;
                    while (k < expr.Length && char.IsWhiteSpace(expr[k])) k++;
                    if (k < expr.Length && (char.IsDigit(expr[k]) || expr[k] == '.'))
                    {
                        number.Append(c); // sign
                        i++;
                        while (i < expr.Length && (char.IsDigit(expr[i]) || expr[i] == '.'))
                        {
                            number.Append(expr[i]);
                            i++;
                        }
                        tokens.Add(number.ToString());
                        number.Clear();
                        expectUnary = false;
                        continue;
                    }
                    // else fallthrough to treat sign as operator
                }

                if (char.IsDigit(c) || c == '.')
                {
                    number.Append(c);
                    i++;
                    while (i < expr.Length && (char.IsDigit(expr[i]) || expr[i] == '.'))
                    {
                        number.Append(expr[i]);
                        i++;
                    }
                    tokens.Add(number.ToString());
                    number.Clear();
                    expectUnary = false;
                    continue;
                }

                // operators and parentheses
                if (c == '+' || c == '-' || c == '*' || c == '/')
                {
                    tokens.Add(c.ToString());
                    expectUnary = true;
                    i++;
                    continue;
                }

                if (c == '(')
                {
                    tokens.Add("(");
                    expectUnary = true;
                    i++;
                    continue;
                }

                if (c == ')')
                {
                    tokens.Add(")");
                    expectUnary = false;
                    i++;
                    continue;
                }

                // unknown character
                throw new ArgumentException("Ký tự không hợp lệ trong biểu thức: " + c);
            }

            return tokens;
        }

        private List<string> ToRpn(List<string> tokens)
        {
            List<string> output = new List<string>();
            Stack<string> ops = new Stack<string>();

            int Prec(string op) => op == "+" || op == "-" ? 1 : (op == "*" || op == "/" ? 2 : 0);

            foreach (var token in tokens)
            {
                if (double.TryParse(token, out _))
                {
                    output.Add(token);
                }
                else if (token == "+" || token == "-" || token == "*" || token == "/")
                {
                    while (ops.Count > 0 && ops.Peek() != "(" &&
                           (Prec(ops.Peek()) > Prec(token) || (Prec(ops.Peek()) == Prec(token))))
                    {
                        output.Add(ops.Pop());
                    }
                    ops.Push(token);
                }
                else if (token == "(")
                {
                    ops.Push(token);
                }
                else if (token == ")")
                {
                    while (ops.Count > 0 && ops.Peek() != "(")
                    {
                        output.Add(ops.Pop());
                    }
                    if (ops.Count == 0 || ops.Peek() != "(")
                        throw new ArgumentException("Mismatched parentheses");
                    ops.Pop();
                }
                else
                {
                    throw new ArgumentException("Token không hợp lệ: " + token);
                }
            }

            while (ops.Count > 0)
            {
                var op = ops.Pop();
                if (op == "(" || op == ")") throw new ArgumentException("Mismatched parentheses");
                output.Add(op);
            }

            return output;
        }

        private double EvalRpn(List<string> rpn)
        {
            Stack<double> st = new Stack<double>();
            foreach (var token in rpn)
            {
                if (double.TryParse(token, out double val))
                {
                    st.Push(val);
                }
                else
                {
                    if (st.Count < 2) throw new ArgumentException("Biểu thức không hợp lệ");
                    double b = st.Pop();
                    double a = st.Pop();
                    double res = token switch
                    {
                        "+" => a + b,
                        "-" => a - b,
                        "*" => a * b,
                        "/" => b == 0 ? throw new DivideByZeroException() : a / b,
                        _ => throw new ArgumentException("Toán tử không hỗ trợ: " + token),
                    };
                    st.Push(res);
                }
            }

            if (st.Count != 1) throw new ArgumentException("Biểu thức không hợp lệ");
            return st.Pop();
        }
    }
}
