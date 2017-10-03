using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopClient
{
    public class CustomScrollBar
    {

        #region Vars
        List<Control> elements = new List<Control>();

        int scrollPos;

        Panel mainPanel;
        int mainPanelHeight;
        int margin;

        Panel scroll;

        int elementsHight;
        #endregion

        public CustomScrollBar(Panel mainPanel, Panel scroll, int margin = 0)
        {
            this.mainPanel = mainPanel;
            this.scroll = scroll;
            scroll.Visible = false;
            this.margin = margin;
            mainPanelHeight = mainPanel.Height;
            scroll.MouseDown += (object sender, MouseEventArgs e) => { scrollPos = e.Y; };
            scroll.MouseMove += (object sender, MouseEventArgs e) => 
            {
                if (e.Button == MouseButtons.Left)
                {
                    var delta = e.Y - scrollPos;
                    if (delta != 0)
                        MoveScroll(delta);
                }
            };

            mainPanel.MouseWheel += (object sender, MouseEventArgs e) => 
            {
                if (e.Delta != 0)
                {
                    if (e.Delta > 0)
                        MoveScroll(-mainPanelHeight / 30);
                    else
                        MoveScroll(mainPanelHeight / 30);
                }
            };
        }

        public void AddNewItem<T>(T item, int x = 0) where T: Control
        {
            int y;
            if (elements.Count == 0)
            {
                y = 0;
            }
            else
            {
                var lastElements = elements.Last();
                y = lastElements.Top + lastElements.Height + margin;
            }
            item.Location = new System.Drawing.Point(x, y);
            elementsHight += item.Height + margin;

            elements.Add(item);
            mainPanel.Controls.Add(item);
            FixScroll();
        }

        public void Clear()
        {
            mainPanel.Controls.Clear();
            elements.Clear();
            scrollPos = 0;
            elementsHight = 0;
        }


        private int ElementsTotalHeight()
        {
            return elementsHight - margin;
        }

        private void FixScroll()
        {
            int scrollHeight = scroll.Height;
            double k = (double)mainPanelHeight / ElementsTotalHeight();
            if (k >= 1.0)
            {
                scroll.Visible = false;
                scrollHeight = (int)(mainPanelHeight * k);
            }
            else
            {
                scroll.Visible = true;
                // control for scroll reduction
                if (scrollHeight >= mainPanelHeight / 4)
                {
                    scrollHeight = (int)(mainPanelHeight * k);
                }
            }
            scroll.Height = scrollHeight;
            scroll.Refresh();
        }

        private void MoveScroll(int distance)
        {
            // how much space out of Main panel size
            int outside = ElementsTotalHeight() - mainPanelHeight;

            if (outside > 0)
            {
                if ((scroll.Top + distance >= 0) && (scroll.Top + distance + scroll.Height <= mainPanelHeight))
                {
                    scroll.Top += distance;
                    var tick = (double)outside / (mainPanelHeight - scroll.Height);

                    foreach (var e in elements)
                    {
                        e.Top -= (int)(distance * tick);
                    }
                }
                else if (scroll.Top + distance < 0)
                {
                    scroll.Top = 0;
                    var offset = elements.First().Top;
                    foreach (var e in elements)
                    {
                        e.Top -= offset;
                    }
                }
                else
                {
                    scroll.Top = mainPanelHeight - scroll.Height;
                    var last = elements.Last();
                    var offset = last.Top - (mainPanelHeight - last.Height);
                    foreach (var e in elements)
                    {
                        e.Top -= offset;
                    }
                }

            }

        }
    }
}
