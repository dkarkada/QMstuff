using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using System.IO;
using System.Drawing.Imaging;
using Accord.Extensions.Imaging;

namespace VideoExportTester {
	public partial class Form1 : Form {
		Random random = new Random();
		List<Bitmap> list = new List<Bitmap>();

		public Form1() {
			InitializeComponent();
			//saveJPEG();
			export();
		}
		public void saveJPEG() {
			Bitmap bmp = new Bitmap(800, 800);
			Directory.CreateDirectory("C:/Users/Dhruva/documents/wtf");
			for(int i = 0; i<1000; i++) {
				using(Graphics g = Graphics.FromImage(bmp)) {
					SolidBrush br = new SolidBrush(Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)));
					g.FillRectangle(br, 50, 50, 200, 200);
				}
				var qualityEncoder = Encoder.Quality;
				var quality = (long)300;
				var ratio = new EncoderParameter(qualityEncoder, quality);
				var codecParams = new EncoderParameters(1);
				codecParams.Param[0] = ratio;
				var jpegCodecInfo = ImageCodecInfo.GetImageEncoders()[0];
				foreach(ImageCodecInfo ici in ImageCodecInfo.GetImageEncoders()) {
					if(ici.MimeType == "image/jpeg")
						jpegCodecInfo = ici;
				}
				bmp.Save("C:/Users/Dhruva/documents/wtf/" + i + ".jpg", jpegCodecInfo, codecParams);
			}
		}
		public void export() {
			DotImaging.ImageStreamWriter w = new DotImaging.VideoWriter("C:/Users/Dhruva/documents/movie.avi",
			new DotImaging.Primitives2D.Size(800, 800), 10, true);
			DotImaging.ImageStreamReader ir = 
				new DotImaging.ImageDirectoryCapture("C:/Users/Dhruva/documents/wtf/", "*.jpg");
			while(ir.Position < ir.Length) {
				DotImaging.IImage i = ir.Read();
				w.Write(i);
			}
			w.Close();
		}
		public void createImages() {
			GifBitmapEncoder gEnc = new GifBitmapEncoder();
			Bitmap bmp = new Bitmap(400, 400);
			int width = 128;
			int height = width;
			int stride = width / 8;

			BitmapSource src;
			BitmapPalette myPalette = BitmapPalettes.Halftone256;

			for (int i=0; i<1000; i++) {
				using (Graphics g = Graphics.FromImage(bmp)) {
					SolidBrush br = new SolidBrush(Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)));
					g.FillRectangle(br, 50, 50, 200, 200);
				}
				src = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
					bmp.GetHbitmap(),
					IntPtr.Zero,
					System.Windows.Int32Rect.Empty,
					BitmapSizeOptions.FromEmptyOptions());
				gEnc.Frames.Add(BitmapFrame.Create(src));
			}
			using (FileStream fs = new FileStream("C:/Users/Dhruva/documents/asd.gif", FileMode.Create)) {
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
