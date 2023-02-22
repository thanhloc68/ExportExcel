using Newtonsoft.Json;
using System.Text.Json;
using Microsoft.Office.Interop.Excel;
using System.Reflection;
namespace exportExcel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtLang.Text = "Tiếng Việt";
            cbbLoaibia.Text = "Bìa mềm";
            txtXuatKhau.Text = "Trong nước";
            txtName.Text = "";
            txtslTonSp.Text = "0";
            txtSlHrv.Text = "0";

            // Read values from file
            var strReadJsonIndustry = File.ReadAllText(@"industry.json");
            // Convert to Json Object
            var getIndustry = JsonConvert.DeserializeObject<List<InDustry>>(strReadJsonIndustry);
            foreach (var value in getIndustry.Select(a => a.Industry_name))
            {
                cbbIndustry.Items.Add(value);
            }
            // Read values from file
            var strReadJson = File.ReadAllText(@"id-brand.json");
            // Convert to Json Object
            var getIdBrand = JsonConvert.DeserializeObject<List<Incident>>(strReadJson);
            foreach (var option in getIdBrand.Select(p => p.name))
            {
                cbbBrand.Items.Add(option);
            }
        }
        void addHaravan(bool hrv)
        {
            if (hrv == false){
                int index = 0;
                DataGridViewRow rowHaravan = (DataGridViewRow)dtgvInfoHaravan.Rows[index].Clone();
                const string quote = "\"";
                List<string> listCollection = new List<string>();
                if (cbbDanhMuc.Text.ToString() != "")
                {
                    string[] collection = cbbDanhMuc.Text.ToString().Split(',');
                    foreach (var everCollection in collection)
                    {
                        listCollection.Add(everCollection);
                    }
                }
                rowHaravan.Cells[0].Value = txtName.Text.ToString(); rowHaravan.Cells[1].Value = txtName.Text.ToString();
                rowHaravan.Cells[2].Value = "<h2 style= " + quote + "text-align: justify;" + quote + "><strong>" + txtName.Text.ToString() + "</strong></h2>" +
                                            "<p style = " + quote + "text-align: justify;" + quote + ">Thông tin sản phẩm </p><table><tbody>" +
                                            "<tr><th style = " + quote + "text-align: justify;" + quote + ">Mã hàng </th>" +
                                            "<td style=" + quote + "text-align:justify" + quote + "> " + txtSKU.Text.ToString() + "</td></tr>" +
                                            "<tr><th style= " + quote + "text-align: justify;" + quote + ">Tên Nhà Cung Cấp</th>" +
                                            "<td style=" + quote + "text-align:justify" + quote + "> " + cbbNCC.Text.ToString() + "</td></tr>" +
                                            "<tr><th style=" + quote + "text-align: justify;" + quote + ">Tác giả</th>" +
                                            "<td style=" + quote + "text-align:justify" + quote + ">" + cbbBrand.Text.ToString() + "</td>" +
                                            "</tr><tr><th style=" + quote + "text-align: justify;" + quote + ">Người Dịch</th>" +
                                            "<td style=" + quote + "text-align:justify" + quote + ">" + txtNguoiDich.Text.ToString() + "</td></tr>" +
                                            "<tr><th style=" + quote + "text-align: justify;" + quote + ">NXB</th>" +
                                            "<td style=" + quote + "text-align:justify" + quote + ">" + txtNXB.Text.ToString() + "</td></tr>" +
                                            "<tr><th style=" + quote + "text-align: justify;" + quote + ">Năm XB</th>" +
                                            "<td style=" + quote + "text-align:justify" + quote + ">" + txtNamsx.Text.ToString() + "</td></tr><tr>" +
                                            "<th style=" + quote + "text-align: justify;" + quote + ">Ngôn Ngữ</th>" +
                                            "<td style=" + quote + "text-align:justify" + quote + ">" + txtLang.Text.ToString() + "</td></tr>" +
                                            "<tr><th style=" + quote + "text-align: justify;" + quote + ">Trọng lượng (gr)</th>" +
                                            "<td style=" + quote + "text-align:justify" + quote + ">" + txtWeight.Text.ToString() + "</td></tr><tr>" +
                                            "<th style=" + quote + "text-align: justify;" + quote + ">Kích Thước Bao Bì</th>" +
                                            "<td style=" + quote + "text-align:justify" + quote + ">" + txtKichThuoc.Text.ToString() + "</td></tr>" +
                                            "<tr><th style=" + quote + "text-align: justify;" + quote + ">Số trang</th><td style=" + quote + "text-align:justify" + quote + "> " + txtSoTrang.Text.ToString() + "</td></tr>" +
                                            "<tr><th style=" + quote + "text-align: justify;" + quote + ">Hình thức</th>" +
                                            "<td style=" + quote + "text-align:justify" + quote + ">" + txtSoTrang.Text.ToString() + "</td></tr></tbody></table>" +
                                            "<p style=" + quote + "text-align: justify;" + quote + ">--------------------------------------------------------------------------------------------------------------------------</p>" +
                                            "<p style=" + quote + "text-align: justify;" + quote + "><strong>" + txtName.Text.ToString() + "</strong></p>" +
                                            "<p style = " + quote + "text-align: justify;" + quote + "> " + txtContent.Text.ToString() + "</p>";
                    rowHaravan.Cells[3].Value = ""; rowHaravan.Cells[4].Value = cbbNCC.Text.ToString(); rowHaravan.Cells[5].Value = txtLoaisp.Text.ToString(); rowHaravan.Cells[6].Value = txtTag.Text.ToString(); rowHaravan.Cells[7].Value = "Yes"; rowHaravan.Cells[8].Value = "Title"; rowHaravan.Cells[9].Value = "Default Title"; rowHaravan.Cells[10].Value = ""; rowHaravan.Cells[11].Value = ""; rowHaravan.Cells[12].Value = ""; rowHaravan.Cells[13].Value = ""; rowHaravan.Cells[14].Value = txtSKU.Text.ToString(); rowHaravan.Cells[15].Value = "100"; rowHaravan.Cells[16].Value = "haravan"; rowHaravan.Cells[17].Value = txtSlHrv.Text.ToString(); rowHaravan.Cells[18].Value = "deny"; rowHaravan.Cells[19].Value = ""; rowHaravan.Cells[20].Value = txtPrice.Text.ToString(); rowHaravan.Cells[21].Value = txtPrice.Text.ToString(); rowHaravan.Cells[22].Value = "Yes"; rowHaravan.Cells[23].Value = "Yes"; rowHaravan.Cells[24].Value = txtSKU.Text.ToString(); rowHaravan.Cells[27].Value = "No"; rowHaravan.Cells[28].Value = txtName.Text.ToString();
                    rowHaravan.Cells[29].Value = txtContent.Text.Substring(0, 70);
                    rowHaravan.Cells[30].Value = ""; rowHaravan.Cells[31].Value = ""; rowHaravan.Cells[32].Value = ""; rowHaravan.Cells[33].Value = ""; rowHaravan.Cells[34].Value = ""; rowHaravan.Cells[35].Value = ""; rowHaravan.Cells[36].Value = ""; rowHaravan.Cells[37].Value = ""; rowHaravan.Cells[39].Value = ""; rowHaravan.Cells[40].Value = ""; rowHaravan.Cells[41].Value = DateTime.Now; rowHaravan.Cells[42].Value = DateTime.Now; rowHaravan.Cells[43].Value = "No"; rowHaravan.Cells[44].Value = "No"; rowHaravan.Cells[45].Value = "Yes"; rowHaravan.Cells[46].Value = "No"; rowHaravan.Cells[47].Value = "No"; rowHaravan.Cells[48].Value = "Yes";
                    rowHaravan.Cells[38].Value = listCollection[0];
                    rowHaravan.Cells[39].Value = listCollection[0];
                    rowHaravan.Cells[25].Value = txtLinkImg1.Text.ToString();
                    rowHaravan.Cells[26].Value = txtName.Text.ToString();
                    dtgvInfoHaravan.Rows.Add(rowHaravan);
                txtSKU.Text = "";
                txtContent.Text = "";
                txtKichThuoc.Text = "";
                txtNguoiDich.Text = "";
                txtSoTrang.Text = "";
                if (txtLinkImg2.Text.ToString() != "" || listCollection[1] != "")
                {
                    index += 1;
                    rowHaravan = (DataGridViewRow)dtgvInfoHaravan.Rows[index].Clone();
                    rowHaravan.Cells[38].Value = listCollection[index];
                    rowHaravan.Cells[39].Value = listCollection[index];
                    rowHaravan.Cells[0].Value = txtName.Text.ToString();
                    rowHaravan.Cells[25].Value = txtLinkImg2.Text.ToString();
                    rowHaravan.Cells[26].Value = txtName.Text.ToString();
                    dtgvInfoHaravan.Rows.Add(rowHaravan);
                }
                if (txtLinkImg3.Text.ToString() != "" || listCollection[2] != "")
                {
                    index += 1;
                    rowHaravan = (DataGridViewRow)dtgvInfoHaravan.Rows[index].Clone();
                    rowHaravan.Cells[38].Value = listCollection[index];
                    rowHaravan.Cells[39].Value = listCollection[index];
                    rowHaravan.Cells[0].Value = txtName.Text.ToString();
                    rowHaravan.Cells[25].Value = txtLinkImg3.Text.ToString();
                    rowHaravan.Cells[26].Value = txtName.Text.ToString();
                    dtgvInfoHaravan.Rows.Add(rowHaravan);
                }
                if (txtLinkImg4.Text.ToString() != "" || listCollection[3] != "")
                {
                    index += 1;
                    rowHaravan = (DataGridViewRow)dtgvInfoHaravan.Rows[index].Clone();
                    rowHaravan.Cells[38].Value = listCollection[index];
                    rowHaravan.Cells[39].Value = listCollection[index];
                    rowHaravan.Cells[0].Value = txtName.Text.ToString();
                    rowHaravan.Cells[25].Value = txtLinkImg4.Text.ToString();
                    rowHaravan.Cells[26].Value = txtName.Text.ToString();
                    dtgvInfoHaravan.Rows.Add(rowHaravan);
                }
                if (txtLinkImg5.Text.ToString() != "" || listCollection[4] != "")
                {
                    index += 1;
                    rowHaravan = (DataGridViewRow)dtgvInfoHaravan.Rows[index].Clone();
                    rowHaravan.Cells[38].Value = listCollection[index];
                    rowHaravan.Cells[39].Value = listCollection[index];
                    rowHaravan.Cells[0].Value = txtName.Text.ToString();
                    rowHaravan.Cells[25].Value = txtLinkImg5.Text.ToString();
                    rowHaravan.Cells[26].Value = txtName.Text.ToString();
                    dtgvInfoHaravan.Rows.Add(rowHaravan);
                }
                if (txtLinkImg6.Text.ToString() != "" || listCollection[5] != "")
                {
                    index += 1;
                    rowHaravan = (DataGridViewRow)dtgvInfoHaravan.Rows[index].Clone();
                    rowHaravan.Cells[38].Value = listCollection[index];
                    rowHaravan.Cells[39].Value = listCollection[index];
                    rowHaravan.Cells[0].Value = txtName.Text.ToString();
                    rowHaravan.Cells[25].Value = txtLinkImg6.Text.ToString();
                    rowHaravan.Cells[26].Value = txtName.Text.ToString();
                    dtgvInfoHaravan.Rows.Add(rowHaravan);
                }
                if (txtLinkImg7.Text.ToString() != "" || listCollection[6] != "")
                {
                    index += 1;
                    rowHaravan = (DataGridViewRow)dtgvInfoHaravan.Rows[index].Clone();
                    rowHaravan.Cells[38].Value = listCollection[index];
                    rowHaravan.Cells[39].Value = listCollection[index];
                    rowHaravan.Cells[0].Value = txtName.Text.ToString();
                    rowHaravan.Cells[25].Value = txtLinkImg7.Text.ToString();
                    rowHaravan.Cells[26].Value = txtName.Text.ToString();
                    dtgvInfoHaravan.Rows.Add(rowHaravan);
                }
                if (txtLinkImg8.Text.ToString() != "" || listCollection[7] != "")
                {
                    index += 1;
                    rowHaravan = (DataGridViewRow)dtgvInfoHaravan.Rows[index].Clone();
                    rowHaravan.Cells[38].Value = listCollection[index];
                    rowHaravan.Cells[39].Value = listCollection[index];
                    rowHaravan.Cells[0].Value = txtName.Text.ToString();
                    rowHaravan.Cells[25].Value = txtLinkImg8.Text.ToString();
                    rowHaravan.Cells[26].Value = txtName.Text.ToString();
                    dtgvInfoHaravan.Rows.Add(rowHaravan);
                }
                if ((txtLinkImg9.Text.ToString() != "") || (listCollection[8] != ""))
                {
                    index += 1;
                    rowHaravan = (DataGridViewRow)dtgvInfoHaravan.Rows[index].Clone();
                    rowHaravan.Cells[0].Value = txtName.Text.ToString();
                    rowHaravan.Cells[38].Value = listCollection[index];
                    rowHaravan.Cells[39].Value = listCollection[index];
                    rowHaravan.Cells[25].Value = txtLinkImg9.Text.ToString();
                    rowHaravan.Cells[26].Value = txtName.Text.ToString();
                    dtgvInfoHaravan.Rows.Add(rowHaravan);
                }
            }
        }
        void addShopee(bool shopee)
        {
            if (shopee == false)
            {
                DataGridViewRow rowShopee = (DataGridViewRow)dtgvInfoShopee.Rows[0].Clone();
                var breakLine = "\n";
                rowShopee.Cells[0].Value = cbbIndustry.Text.ToString(); rowShopee.Cells[1].Value = "Sách - " + txtName.Text.ToString();
                //rowShopee.Cells[2].Value = txtContent.Text.ToString();
                rowShopee.Cells[2].Value =  "Mã hàng: " + txtSKU.Text.ToString() + breakLine +
                                            breakLine + "Tên Nhà Cung Cấp: " + cbbNCC.Text.ToString() + breakLine +
                                            breakLine + "Tác giả: " + cbbBrand.Text.ToString() + breakLine +
                                            breakLine + "Người Dịch: " + txtNguoiDich.Text.ToString() + breakLine +
                                            breakLine + "NXB: " + txtNXB.Text.ToString() + breakLine +
                                            breakLine + "Năm XB: " + txtNamsx.Text.ToString() + breakLine +
                                            breakLine + "Ngôn Ngữ " + txtLang.Text.ToString() + breakLine +
                                            breakLine + "Trọng lượng (gr): " + txtWeight.Text.ToString() + breakLine +
                                            breakLine + "Kích Thước Bao Bì: " + txtKichThuoc.Text.ToString() + breakLine +
                                            breakLine + "Số trang: " + txtSoTrang.Text.ToString() + breakLine +
                                            breakLine + "Hình thức: " + txtSoTrang.Text.ToString() + breakLine +
                                            breakLine + ">--------------------------------------------------------------------------------------------------------------------------<" + breakLine +
                                            breakLine + txtName.Text.ToString() + breakLine +
                                            breakLine + txtContent.Text.ToString();
                rowShopee.Cells[3].Value = txtSKU.Text.ToString(); rowShopee.Cells[4].Value = ""; rowShopee.Cells[5].Value = ""; rowShopee.Cells[6].Value = ""; rowShopee.Cells[7].Value = ""; rowShopee.Cells[8].Value = ""; rowShopee.Cells[9].Value = ""; rowShopee.Cells[10].Value = txtPrice.Text.ToString(); rowShopee.Cells[11].Value = txtslTonSp.Text.ToString(); rowShopee.Cells[12].Value = ""; rowShopee.Cells[13].Value = ""; rowShopee.Cells[14].Value = txtLinkImg1.Text.ToString(); rowShopee.Cells[15].Value = txtLinkImg2.Text.ToString(); rowShopee.Cells[16].Value = txtLinkImg3.Text.ToString(); rowShopee.Cells[17].Value = txtLinkImg4.Text.ToString(); rowShopee.Cells[18].Value = txtLinkImg5.Text.ToString(); rowShopee.Cells[19].Value = txtLinkImg6.Text.ToString(); rowShopee.Cells[20].Value = txtLinkImg7.Text.ToString(); rowShopee.Cells[21].Value = txtLinkImg8.Text.ToString(); rowShopee.Cells[22].Value = txtLinkImg9.Text.ToString(); rowShopee.Cells[23].Value = txtWeight.Text.ToString(); rowShopee.Cells[24].Value = ""; rowShopee.Cells[25].Value = ""; rowShopee.Cells[26].Value = ""; rowShopee.Cells[27].Value = "Mở"; rowShopee.Cells[28].Value = "=IFERROR(VLOOKUP(@INDIRECT(ADDRESS(ROW(),1)),FilterProhibitCat!$A$1:$EA$20000,3,0)," + "" + ")"; rowShopee.Cells[29].Value = ""; rowShopee.Cells[30].Value = txtIdBrand.Text.ToString(); rowShopee.Cells[31].Value = txtXuatKhau.Text.ToString(); rowShopee.Cells[32].Value = ""; rowShopee.Cells[33].Value = ""; rowShopee.Cells[34].Value = txtNXB.Text.ToString(); rowShopee.Cells[35].Value = ""; rowShopee.Cells[36].Value = txtLang.Text.ToString(); rowShopee.Cells[37].Value = txtXuatKhau.Text.ToString(); rowShopee.Cells[38].Value = ""; rowShopee.Cells[39].Value = ""; rowShopee.Cells[40].Value = ""; rowShopee.Cells[41].Value = ""; rowShopee.Cells[42].Value = cbbLoaibia.Text.ToString(); rowShopee.Cells[43].Value = txtNamsx.Text.ToString(); rowShopee.Cells[44].Value = ""; rowShopee.Cells[45].Value = ""; rowShopee.Cells[46].Value = "";
                dtgvInfoShopee.Rows.Add(rowShopee);
            }
        }
  
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //dtgvInfo.Rows.Add(txtName.Text.ToString(), txtContent.Text.ToString(), txtIdBrand.Text.ToString(), txtXuatKhau.Text.ToString(), txtLang.Text.ToString(), txtNXB.Text.ToString(), txtLoaiBia.Text.ToString(), txtNamsx.Text.ToString(), txtPrice.Text.ToString(), txtslTon.Text.ToString(), txtWeight.Text.ToString(), txtSKU.Text.ToString(), txtLinkImg1.Text.ToString());

                //--------------------------Add Datagridview cho Haravan-----------------------------------------------------------------------//
                addShopee(false);
                //-------------------------------------------------------------------------------------------------//
                //--------------------------Add Datagridview cho Shopee-----------------------------------------------------------------------//
                addHaravan(false);
                clear();
                //-------------------------------------------------------------------------------------------------//
            }
            catch { }
        }
        void clear()
        {
            txtName.Text = "";
            txtContent.Text = "";
            txtIdBrand.Text = "";
            //txtNXB.Text = "";
            txtPrice.Text = "";
            txtslTonSp.Text = "";
            txtSlHrv.Text = "";
            txtSKU.Text = "";
            txtLinkImg1.Text = ""; txtLinkImg2.Text = ""; txtLinkImg3.Text = ""; txtLinkImg4.Text = ""; txtLinkImg5.Text = ""; txtLinkImg6.Text = ""; txtLinkImg7.Text = ""; txtLinkImg8.Text = ""; txtLinkImg9.Text = "";
        }
        private void btnGetId_Click(object sender, EventArgs e)
        {
            try { 
            // Read values from file
            var strReadJson = File.ReadAllText(@"id-brand.json");
            // Convert to Json Object
            var x = JsonConvert.DeserializeObject<List<Incident>>(strReadJson);
            if ((cbbBrand.SelectedIndex > -1) || (cbbBrand.Text != null))
            {
                txtIdBrand.Text = x.Where(x => x.name == cbbBrand.Text.ToString()).Select(x => x.brand_id.ToString()).FirstOrDefault();
            }
            else
            {
                MessageBox.Show("Không có thông tin","Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            }
            catch
            {

            }
        }
        private void btnExportShopee_Click(object sender, EventArgs e)
        {
            try
            {
                exportExcelShopee();
            }
            catch (Exception ex)
            {
            }
        }
        public class Incident
        {
            public Incident()
            {
            }
            public Incident(string id, string names, string display_names)
            {
                brand_id = id;
                name = names;
                display_name = display_names;
            }
            public string brand_id { get; set; }
            public string name { get; set; }
            public string display_name { get; set; }
        }

        public class InDustry
        {
            public InDustry() { }
            public InDustry(string idIndustry, string namesIndustry)
            {
                id_Industry = idIndustry;
                Industry_name = namesIndustry;
            }
            public string id_Industry { get; set; }
            public string Industry_name { get; set; }
        }

        private void dtgvInfo_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                cbbIndustry.Text = this.dtgvInfoShopee.CurrentRow.Cells[0].Value.ToString();
                txtName.Text = this.dtgvInfoShopee.CurrentRow.Cells[1].Value.ToString();
                txtContent.Text = this.dtgvInfoShopee.CurrentRow.Cells[2].Value.ToString();
                txtSKU.Text = this.dtgvInfoShopee.CurrentRow.Cells[3].Value.ToString();
                txtPrice.Text = this.dtgvInfoShopee.CurrentRow.Cells[10].Value.ToString();
                txtslTonSp.Text = this.dtgvInfoShopee.CurrentRow.Cells[11].Value.ToString();
                txtLinkImg1.Text = this.dtgvInfoShopee.CurrentRow.Cells[14].Value.ToString();
                txtLinkImg2.Text = this.dtgvInfoShopee.CurrentRow.Cells[15].Value.ToString();
                txtLinkImg3.Text = this.dtgvInfoShopee.CurrentRow.Cells[16].Value.ToString();
                txtLinkImg4.Text = this.dtgvInfoShopee.CurrentRow.Cells[17].Value.ToString();
                txtLinkImg5.Text = this.dtgvInfoShopee.CurrentRow.Cells[18].Value.ToString();
                txtLinkImg6.Text = this.dtgvInfoShopee.CurrentRow.Cells[19].Value.ToString();
                txtLinkImg7.Text = this.dtgvInfoShopee.CurrentRow.Cells[20].Value.ToString();
                txtLinkImg8.Text = this.dtgvInfoShopee.CurrentRow.Cells[21].Value.ToString();
                txtLinkImg9.Text = this.dtgvInfoShopee.CurrentRow.Cells[22].Value.ToString();
                txtWeight.Text = this.dtgvInfoShopee.CurrentRow.Cells[23].Value.ToString();
                txtIdBrand.Text = this.dtgvInfoShopee.CurrentRow.Cells[30].Value.ToString();
                cbbLoaibia.Text = this.dtgvInfoShopee.CurrentRow.Cells[42].Value.ToString();
                txtNamsx.Text = this.dtgvInfoShopee.CurrentRow.Cells[43].Value.ToString();
            }
            catch { }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            dtgvInfoShopee.Rows.Clear();
            dtgvInfoHaravan.Rows.Clear();
        }

        private void btnExportHaravan_Click(object sender, EventArgs e)
        {
            try
            {
                exportExcelHaravan();
            }
            catch (Exception ex)
            {
            }
        }
        void exportExcelHaravan()
        {
            // creating Excel Application  
            _Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application  
            _Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            _Worksheet worksheet = null;
            // see the excel sheet behind the program  
            app.Visible = true;
            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            // changing the name of active sheet  
            worksheet.Name = "Sheet1";
            // storing header part in Excel  
            for (int i = 1; i < dtgvInfoHaravan.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dtgvInfoHaravan.Columns[i - 1].HeaderText;

            }
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < dtgvInfoHaravan.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dtgvInfoHaravan.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dtgvInfoHaravan.Rows[i].Cells[j].Value?.ToString();
                }
            }
            //app.DisplayAlerts = false;
            // save the application  
            workbook.SaveAs2("d:\\xuatharavanvashopee\\haravan.xls", XlFileFormat.xlExcel8, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            // Exit from the application  
            app.Quit();
        }
        void exportExcelShopee()
        {
            // creating Excel Application  
            _Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application  
            _Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            _Worksheet worksheet = null;
            // see the excel sheet behind the program  
            app.Visible = true;
            app.AlertBeforeOverwriting = false;
            app.DisplayAlerts = false;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            // changing the name of active sheet  
            // get the reference of first sheet. By default its name is Sheet2.  

            worksheet.Name = @"Phạm vi ngày chuẩn bị hàng";
            worksheet.Cells[1, 1] = "100643 - ";

            // get the reference of first sheet. By default its name is Sheet3.
            Worksheet oSheet3 = workbook.Sheets.Add(Type.Missing, Type.Missing, 1, Type.Missing);
            oSheet3.Name = @"Đăng tải bản mẫu";
            oSheet3.Cells[1, 1] = "ps_category";oSheet3.Cells[1, 2] = "ps_product_name";oSheet3.Cells[1, 3] = "ps_product_description";oSheet3.Cells[1, 4] = "ps_sku_parent_short";oSheet3.Cells[1, 5] = "et_title_variation_integration_no";oSheet3.Cells[1, 6] = "et_title_variation_1";oSheet3.Cells[1, 7] = "et_title_option_for_variation_1";oSheet3.Cells[1, 8] = "et_title_image_per_variation";oSheet3.Cells[1, 9] = "et_title_variation_2";oSheet3.Cells[1, 10] = "et_title_option_for_variation_2";oSheet3.Cells[1, 11] = "ps_price";oSheet3.Cells[1, 12] = "ps_stock";oSheet3.Cells[1, 13] = "ps_sku_short";oSheet3.Cells[1, 14] = "ps_item_cover_image";oSheet3.Cells[1, 15] = "ps_item_image_1";oSheet3.Cells[1, 16] = "ps_item_image_2";oSheet3.Cells[1, 17] = "ps_item_image_3";oSheet3.Cells[1, 18] = "ps_item_image_4";oSheet3.Cells[1, 19] = "ps_item_image_5";oSheet3.Cells[1, 20] = "ps_item_image_6";oSheet3.Cells[1, 21] = "ps_item_image_7";oSheet3.Cells[1, 22] = "ps_item_image_8";oSheet3.Cells[1, 23] = "ps_weight";oSheet3.Cells[1, 24] = "ps_length";oSheet3.Cells[1, 25] = "ps_width";oSheet3.Cells[1, 26] = "ps_height";oSheet3.Cells[1, 27] = "channel_id_";oSheet3.Cells[1, 28] = "channel_id_";oSheet3.Cells[1, 29] = "channel_id_";oSheet3.Cells[1, 30] = "ps_product_pre_order_dts_range";oSheet3.Cells[1, 31] = "ps_product_pre_order_dts";oSheet3.Cells[1, 32] = "";oSheet3.Cells[1, 33] = "";oSheet3.Cells[1, 34] = "";oSheet3.Cells[1, 35] = "";oSheet3.Cells[1, 36] = "";oSheet3.Cells[1, 37] = "";oSheet3.Cells[1, 38] = "";oSheet3.Cells[1, 39] = "";oSheet3.Cells[1, 40] = "";oSheet3.Cells[1, 41] = "";oSheet3.Cells[1, 42] = "ps_tool_mass_upload_sample_attr_country_origin";oSheet3.Cells[1, 43] = "";oSheet3.Cells[1, 44] = "";oSheet3.Cells[1, 45] = "";oSheet3.Cells[1, 46] = "";oSheet3.Cells[1, 47] = "";
            // Sheet2
            Worksheet oSheet2 = workbook.Sheets.Add(Type.Missing, Type.Missing, 1, Type.Missing);
            oSheet2.Name = @"Bản đăng tải";
            oSheet2.Cells[1, 1] = "ps_category";oSheet2.Cells[1, 2] = "ps_product_name";oSheet2.Cells[1, 3] = "ps_product_description";oSheet2.Cells[1, 4] = "ps_sku_parent_short";oSheet2.Cells[1, 5] = "et_title_variation_integration_no";oSheet2.Cells[1, 6] = "et_title_variation_1";oSheet2.Cells[1, 7] = "et_title_option_for_variation_1";oSheet2.Cells[1, 8] = "et_title_image_per_variation";oSheet2.Cells[1, 9] = "et_title_variation_2";oSheet2.Cells[1, 10] = "et_title_option_for_variation_2";oSheet2.Cells[1, 11] = "ps_price";oSheet2.Cells[1, 12] = "ps_stock";oSheet2.Cells[1, 13] = "ps_sku_short";oSheet2.Cells[1, 14] = "ps_new_size_chart";oSheet2.Cells[1, 15] = "ps_item_cover_image";oSheet2.Cells[1, 16] = "ps_item_image_1";oSheet2.Cells[1, 17] = "ps_item_image_2";oSheet2.Cells[1, 18] = "ps_item_image_3";oSheet2.Cells[1, 19] = "ps_item_image_4";oSheet2.Cells[1, 20] = "ps_item_image_5";oSheet2.Cells[1, 21] = "ps_item_image_6";oSheet2.Cells[1, 22] = "ps_item_image_7";oSheet2.Cells[1, 23] = "ps_item_image_8";oSheet2.Cells[1, 24] = "ps_weight";oSheet2.Cells[1, 25] = "ps_length";oSheet2.Cells[1, 26] = "ps_width";oSheet2.Cells[1, 27] = "ps_height";oSheet2.Cells[1, 28] = "channel_id_5001";oSheet2.Cells[1, 29] = "ps_product_pre_order_dts_range";oSheet2.Cells[1, 30] = "ps_product_pre_order_dts";oSheet2.Cells[1, 31] = "ps_brand";oSheet2.Cells[1, 32] = "ps_product_global_attribute_100037";oSheet2.Cells[1, 33] = "ps_product_global_attribute_100121";oSheet2.Cells[1, 34] = "ps_product_global_attribute_100370";oSheet2.Cells[1, 35] = "ps_product_global_attribute_100669";oSheet2.Cells[1, 36] = "ps_product_global_attribute_100670";oSheet2.Cells[1, 37] = "ps_product_global_attribute_100673";oSheet2.Cells[1, 38] = "ps_product_global_attribute_100676";oSheet2.Cells[1, 39] = "ps_product_global_attribute_100691";oSheet2.Cells[1, 40] = "ps_product_global_attribute_100697";oSheet2.Cells[1, 41] = "ps_product_global_attribute_100707";oSheet2.Cells[1, 42] = "ps_product_global_attribute_100709";oSheet2.Cells[1, 43] = "ps_product_global_attribute_100710";oSheet2.Cells[1, 44] = "ps_product_global_attribute_101024";oSheet2.Cells[1, 45] = "ps_product_global_attribute_101059";oSheet2.Cells[1, 46] = "ps_product_global_attribute_101067";oSheet2.Cells[1, 47] = "ps_product_global_attribute_101068";

            // storing header part in Excel
            for (int i = 1; i < dtgvInfoShopee.Columns.Count + 1; i++)
            {
                oSheet2.Cells[2, i] = dtgvInfoShopee.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < dtgvInfoShopee.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dtgvInfoShopee.Columns.Count; j++)
                {
                    oSheet2.Cells[i + 6, j + 1] = dtgvInfoShopee.Rows[i].Cells[j].Value?.ToString();
                }
            }

            // Sheet4
            Worksheet oSheet4 = workbook.Sheets.Add(Type.Missing, Type.Missing, 1, Type.Missing);
            oSheet4.Name = @"Hướng dẫn";
            oSheet4.Cells[2, 1] = "advance";
            oSheet4.Cells[2, 2] = "220309_sizechart";

            // save the application  

            app.AskToUpdateLinks = false;
            app.DisplayAlerts = false;
            workbook.SaveAs2("d:\\xuatharavanvashopee\\shopee.xlsx", Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            // Exit from the application  
            app.Quit();
        }
        private void btnExportAll_Click(object sender, EventArgs e)
        {
            exportExcelShopee();
            exportExcelHaravan();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //DataGridViewRow UpRowShopee = (DataGridViewRow)dtgvInfoShopee.CurrentRow.DataBoundItem;
            //UpRowShopee.CurrentRow.Cells[1].Value.ToString() = txtName.Text.ToString();
        }
    }
}