using FECoffe.DTO.OrderDetails;
using System.Printing;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Xps;

namespace FECoffe.Form.FrmDisplay
{
    /// <summary>
    /// Interaction logic for InvoicePreviewWindow.xaml
    /// </summary>
    public partial class InvoicePreviewWindow : Window
    {
        private FlowDocument _document;

        public InvoicePreviewWindow(IEnumerable<CartItem> cartItems, string customerName, decimal discount)
        {
            InitializeComponent();
            _document = CreateInvoiceDocument(cartItems, customerName, discount);
            docViewer.Document = _document;
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            // In thẳng, không mở hộp thoại
            try
            {
                LocalPrintServer localPrintServer = new LocalPrintServer();
                PrintQueue defaultPrintQueue = localPrintServer.DefaultPrintQueue;

                if (defaultPrintQueue == null)
                {
                    MessageBox.Show("Không tìm thấy máy in mặc định!", "Lỗi in", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                XpsDocumentWriter writer = PrintQueue.CreateXpsDocumentWriter(defaultPrintQueue);
                writer.Write(((IDocumentPaginatorSource)_document).DocumentPaginator);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể in hóa đơn: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private FlowDocument CreateInvoiceDocument(IEnumerable<CartItem> cartItems, string customerName, decimal discount)
        {
            FlowDocument doc = new FlowDocument
            {
                FontFamily = new FontFamily("Segoe UI"),
                FontSize = 9,
                PageWidth = 210, // ~K57
                ColumnWidth = double.PositiveInfinity,
                PagePadding = new Thickness(5),
                TextAlignment = TextAlignment.Left
            };

            // Tiêu đề
            Paragraph title = new Paragraph(new Run("HÓA ĐƠN"))
            {
                FontSize = 14,
                FontWeight = FontWeights.Bold,
                TextAlignment = TextAlignment.Center,
                Margin = new Thickness(0, 0, 0, 8)
            };
            doc.Blocks.Add(title);

            doc.Blocks.Add(new Paragraph(new Run("Lặng Coffee"))
            {
                FontSize = 11,
                TextAlignment = TextAlignment.Center,
                Margin = new Thickness(0, 0, 0, 2)
            });

            doc.Blocks.Add(new Paragraph(new Run($"Nhân viên: {customerName}"))
            {
                FontSize = 11,
                TextAlignment = TextAlignment.Center,
                Margin = new Thickness(0, 0, 0, 2)
            });

            doc.Blocks.Add(new Paragraph(new Run($"Thời gian: {DateTime.Now:dd/MM/yyyy HH:mm}"))
            {
                FontSize = 11,
                TextAlignment = TextAlignment.Center,
                Margin = new Thickness(0, 0, 0, 6)
            });

            // Tạo bảng sản phẩm
            Table table = new Table
            {
                CellSpacing = 0
            };

            table.Columns.Add(new TableColumn { Width = new GridLength(90) });  // Tên món
            table.Columns.Add(new TableColumn { Width = new GridLength(20) });  // SL
            table.Columns.Add(new TableColumn { Width = new GridLength(50) });  // Thành tiền

            TableRowGroup rowGroup = new TableRowGroup();

            // Header
            TableRow header = new TableRow();
            header.Cells.Add(CreateCell("Tên", true));
            header.Cells.Add(CreateCell("SL", true));
            header.Cells.Add(CreateCell("T.tiền", true));
            rowGroup.Rows.Add(header);

            decimal totalAmount = 0;

            foreach (var item in cartItems)
            {
                TableRow row = new TableRow();
                row.Cells.Add(CreateCell(item.Name + " - " + item.Topping));
                row.Cells.Add(CreateCell(item.Quantity.ToString()));
                row.Cells.Add(CreateCell(item.Total.ToString("N0")));
                rowGroup.Rows.Add(row);

                totalAmount += item.Total;
            }

            table.RowGroups.Add(rowGroup);

            // Căn giữa bảng bằng Section
            Section tableSection = new Section { TextAlignment = TextAlignment.Center };
            tableSection.Blocks.Add(table);
            doc.Blocks.Add(tableSection);

            // Tính thành tiền sau phụ thu
            decimal finalprice = discount > 0 && discount <= 100
                ? totalAmount + (totalAmount * discount / 100)
                : totalAmount;

            // Phụ thu
            if (discount > 0)
            {
                Paragraph dis = new Paragraph(new Run($"Phụ thu: {discount}%"))
                {
                    FontSize = 9,
                    TextAlignment = TextAlignment.Right,
                    Margin = new Thickness(0, 10, 0, 0)
                };
                doc.Blocks.Add(dis);
            }

            // Tổng cộng
            Paragraph total = new Paragraph(new Run($"Tổng cộng: {totalAmount:N0}đ"))
            {
                FontSize = 9,
                TextAlignment = TextAlignment.Right,
                Margin = new Thickness(0, 6, 0, 0)
            };
            doc.Blocks.Add(total);

            Paragraph final = new Paragraph(new Run($"Thành tiền: {finalprice:N0}đ"))
            {
                FontSize = 11,
                FontWeight = FontWeights.Bold,
                TextAlignment = TextAlignment.Right,
                Margin = new Thickness(0, 4, 0, 0)
            };
            doc.Blocks.Add(final);

            return doc;
        }


        private TableCell CreateCell(string text, bool isHeader = false)
        {
            var paragraph = new Paragraph(new Run(text))
            {
                TextAlignment = TextAlignment.Center,
                FontSize = isHeader ? 11 : 10,
                FontWeight = isHeader ? FontWeights.Bold : FontWeights.Normal,
                Margin = new Thickness(1),
                Padding = new Thickness(0)
            };

            return new TableCell(paragraph);
        }


    }
}
