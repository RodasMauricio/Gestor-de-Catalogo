using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Negocio
{
    public static class Ayuda
    {
        public static void CargarPB(string img, PictureBox pb)
        {
			try
			{
				pb.Load(img);
			}
			catch (Exception)
			{
				pb.Load("https://cdn.pixabay.com/photo/2015/12/22/04/00/photo-1103595_1280.png");
			}
        }


    }
}
