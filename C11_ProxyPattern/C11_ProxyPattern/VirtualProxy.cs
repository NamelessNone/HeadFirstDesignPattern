using System.Security.Policy;
using System.Threading;

namespace C11_ProxyPattern
{
    public interface IIcon
    {
        int GetIconWidth();
        int GetIconHeight();
        void PaintIcon();
    }
    
    
    public class ImageIcon: IIcon
    {
        public int GetIconWidth(){ return 1;}

        public int GetIconHeight()
        {
            return 1;
            
        }
        public void PaintIcon(){}
    }
    
    public class ImageProxy: IIcon
    {
        private ImageIcon _imageIcon;
        private Url _imageUrl;
        private Thread _retrievalThread;
        private bool _retrieving = false;

        public ImageProxy(Url url)
        {
            _imageUrl = url;
        }

        public int GetIconWidth()
        {
            if (_imageIcon != null)
            {
                return _imageIcon.GetIconWidth();
            }
            else
            {
                return 1;
            }
        }

        public int GetIconHeight()
        {
            if (_imageIcon != null)
            {
                return _imageIcon.GetIconHeight();
            }
            else
            {
                return 1;
            }
            
        }

        public void PaintIcon()
        {
            if (_imageIcon != null)
            {
                _imageIcon.PaintIcon();
            }
            else
            {
                
            }
        }
    }
}