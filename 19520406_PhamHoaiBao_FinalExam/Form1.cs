using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _19520406_PhamHoaiBao_FinalExam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            KVNT.Checked = true; //Mac dinh Khu vuc la Nong Thon

        }
        private void Tinh_Click(object sender, EventArgs e)
        {
            int Sl = 0;
            if (SoLuongTB.Text != "") // 0 mac dinh
                Sl = Int32.Parse(SoLuongTB.Text);
            else SoLuongTB.Text = "0";

            int DonGia = 0;
            if (DongiaTB.Text != "")//0 mac dinh
                DonGia = (Int32.Parse(DongiaTB.Text));
            else DongiaTB.Text = "0";
            //Tinh Thanh Tien
            int Thanhtien = Sl * DonGia;
            ThanhTienTB.Text = Thanhtien.ToString();
            //Tinh Thue VAT
            VatTB.Text = ((double)Thanhtien * 0.1).ToString();
            //Tinh Giam gia
            double giamgia = 0;
            if (KVNT.Checked == true) giamgia = Thanhtien * 0.15;
            if (KVTP.Checked == true) giamgia = Thanhtien * 0.1;
            GiamGiaTB.Text = giamgia.ToString();
            //Tinh Tong Tien
            double Tongtien = Thanhtien * 1.1 - giamgia;
            TongTienTb.Text = Tongtien.ToString();
        }

        private void Xoa_Click(object sender, EventArgs e)
        {
            //Reset Textbox
            TongTienTb.Text = "";
            GiamGiaTB.Text = "";
            VatTB.Text = "";
            ThanhTienTB.Text = "";
            DongiaTB.Text = "";
            SoLuongTB.Text = "";
            KVNT.Checked = true;
            KVTP.Checked = false;
            TenTB.Text = "";
            DiaChiTB.Text = "";
        }

        private void Them_Click(object sender, EventArgs e)
        {
            //Nhan nut Tinh
            Tinh_Click(sender, e);
            //Lay thong tin tu radioButton
            string khuvuc;
            if (KVNT.Checked == true) 
                khuvuc = "Nông Thôn";
            else 
                khuvuc = "Thành Thị";
            //Them du lieu
            dataGridView1.Rows.Add(TenTB.Text, DiaChiTB.Text, khuvuc, SoLuongTB.Text, DongiaTB.Text, ThanhTienTB.Text, VatTB.Text, GiamGiaTB.Text, TongTienTb.Text);
        }

        private void SlTB_KeyPress(object sender, KeyPressEventArgs e)
        { //Chi duoc nhap So 
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void DongiaTB_KeyPress(object sender, KeyPressEventArgs e)
        {//Chi duoc nhap so
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {          
                if (MessageBox.Show("Có Muốn Thoát", "Form",
                   MessageBoxButtons.YesNo) == DialogResult.No) 
                    e.Cancel = true;      
        }
    }
}
