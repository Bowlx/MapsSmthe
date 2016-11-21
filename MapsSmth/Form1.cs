using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace MapsSmth
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {

            InitializeComponent();
            
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            



               gMapControl1.Bearing = 0;       
            gMapControl1.CanDragMap = true;           
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.GrayScaleMode = true;      
            gMapControl1.MarkersEnabled = true;
            gMapControl1.MaxZoom = 18;
            gMapControl1.MinZoom = 2;
            gMapControl1.MouseWheelZoomType =
                GMap.NET.MouseWheelZoomType.MousePositionAndCenter;

            //Отказываемся от негативного режима.
            gMapControl1.NegativeMode = false;

            //Разрешаем полигоны.
            gMapControl1.PolygonsEnabled = true;

            //Разрешаем маршруты
            gMapControl1.RoutesEnabled = true;

            //Скрываем внешнюю сетку карты
            //с заголовками.
            gMapControl1.Dock = DockStyle.Fill;
            gMapControl1.ShowTileGridLines = false;
            //Указываем, что при загрузке карты будет использоваться 
            //18ти кратное приближение.
            gMapControl1.Zoom = 15;

            //Указываем что все края элемента управления
            //закрепляются у краев содержащего его элемента
            //управления(главной формы), а их размеры изменяются 
            //соответствующим образом.
            

            //Указываем что будем использовать карты Google.
            gMapControl1.MapProvider =
            GMap.NET.MapProviders.GMapProviders.GoogleMap;
            GMap.NET.GMaps.Instance.Mode =
                GMap.NET.AccessMode.ServerOnly;
            gMapControl1.Position = new GMap.NET.PointLatLng(59.926606, 30.339124);
            

        }

        private void gMapControl1_MouseClick(object sender, MouseEventArgs e)
        {
            GMapOverlay overlayOne =new GMapOverlay();
            overlayOne.Markers.Clear();
            double lat = 0.0;
            double lng = 0.0;
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                //Получаем координаты, где устанавливается новый маркер.
                lat = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lat;
                lng = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lng;               
                PointLatLng memesLatLng = new PointLatLng(lat, lng);
                GMarkerGoogle marker = new
                 GMarkerGoogle(memesLatLng, GMarkerGoogleType.blue);
                marker.ToolTip =
                new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(marker);

                //Указываем в качестве текста подсказки,
                //координаты где установлен маркер.
                marker.ToolTipText = lat.ToString() + ";" +
                    
                    Environment.NewLine +
                    lng.ToString() + ";";
                overlayOne.Markers.Add(marker);
                gMapControl1.Overlays.Add(overlayOne);
                gMapControl1.Zoom += 1;
                gMapControl1.Zoom -= 1;                
            }
            

        }
    }
}
