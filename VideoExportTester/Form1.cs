using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using System.IO;

namespace VideoExportTester {
	public partial class Form1 : Form {
		Random random = new Random();
		List<Bitmap> list = new List<Bitmap>();

		public Form1() {
			InitializeComponent();
			createImages();
	//		createGif();
		}
		public void createImages() {
			GifBitmapEncoder gEnc = new GifBitmapEncoder();
			Bitmap bmp = new Bitmap(800, 800);
			for (int i=0; i<1000; i++) {
				using (Graphics g = Graphics.FromImage(bmp)) {
					SolidBrush br = new SolidBrush(Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)));
					g.FillRectangle(br, 50, 50, 200, 200);
				}
				BitmapSource src = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
				bmp.GetHbitmap(),
				IntPtr.Zero,
				System.Windows.Int32Rect.Empty,
				BitmapSizeOptions.FromEmptyOptions());
				gEnc.Frames.Add(BitmapFrame.Create(src));
				list.Add(bmp);
			}
			using (FileStream fs = new FileStream("C:/Users/dkarkada/documents/asd.gif", FileMode.Create)) {
				gEnc.Save(fs);
			}
		}
		public void createGif() {
			GifBitmapEncoder gEnc = new GifBitmapEncoder();

			int ct = 0;
			foreach (Bitmap bmp in list) {
				Console.WriteLine(ct);
				ct++;
				BitmapSource src = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
					bmp.GetHbitmap(),
					IntPtr.Zero,
					System.Windows.Int32Rect.Empty,
					BitmapSizeOptions.FromEmptyOptions());
				gEnc.Frames.Add(BitmapFrame.Create(src));
				
			}
			using (FileStream fs = new FileStream("C:/Users/dkarkada/documents/asd.gif", FileMode.Create)) {
				gEnc.Save(fs);
			}
		}
	}
}
