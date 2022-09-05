using System.Drawing.Imaging;

namespace WinFormsPictureBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox.ImageLocation = @"C:\Users\xxxx\Downloads\xxxx.jpg";
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                SavePictureBoxImage();
            }
        }

        private void SavePictureBoxImage()
        {
            try
            {
                string filePath = pictureBox.ImageLocation;
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException();
                }
    
                using (var sfd = new SaveFileDialog())
                {
                    sfd.FileName = Path.GetFileName(filePath);
                    sfd.Filter = "JPG|*.jpg|PNG|*.png|All files(*.*)|*.*";            
                    sfd.RestoreDirectory = true;
    
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {                
                        pictureBox.Image.Save(sfd.FileName, ImageFormat.Jpeg);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The file not found�B", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}