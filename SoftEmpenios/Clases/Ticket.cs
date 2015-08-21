using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Collections;

namespace SoftEmpenios.Clases
{
    public class Ticket
    {
        ArrayList headerLines = new ArrayList();
        ArrayList subHeaderLines = new ArrayList();
        ArrayList items = new ArrayList();
        ArrayList totales = new ArrayList();
        ArrayList footerLines = new ArrayList();
        private Image headerImage = null;

        // bool _venta; // Es para ver si es venta o pago
        int _venta;      //  1 es venta, 2 es pago, 3 no lleva encabezado
        int count = 0;

        int maxChar = 40;
        int maxCharDescription = 25;

        int imageHeight = 0;

        float leftMargin = 0;
        float topMargin = 3;

        string fontName = "FontA11";
        int fontSize = 9;

        Font printFont = null;
        SolidBrush myBrush = new SolidBrush(Color.Black);

        Graphics gfx = null;

        string line = null;

        public Ticket(int Venta)
        {
            _venta = Venta;
        }

        public Image HeaderImage
        {
            get { return headerImage; }
            set { if (headerImage != value) headerImage = value; }
        }

        public int MaxChar
        {
            get { return maxChar; }
            set { if (value != maxChar) maxChar = value; }
        }

        public int MaxCharDescription
        {
            get { return maxCharDescription; }
            set { if (value != maxCharDescription) maxCharDescription = value; }
        }

        public int FontSize
        {
            get { return fontSize; }
            set { if (value != fontSize) fontSize = value; }
        }

        public string FontName
        {
            get { return fontName; }
            set { if (value != fontName) fontName = value; }
        }

        public void AddHeaderLine(string line)
        {
            headerLines.Add(line);
        }

        public void AddSubHeaderLine(string line)
        {
            subHeaderLines.Add(line);
        }

        public void AddItem(string cantidad, string item, string price)
        {
            OrderItem newItem = new OrderItem('?');
            items.Add(newItem.GenerateItem(cantidad, item, price));
        }
        public void AddItem(string cvepago, string interes, string recargo,string total, string mes)
        {
            OrderItem newItem = new OrderItem('?');
            items.Add(newItem.GenerateItem(cvepago, interes, recargo,total,mes));
        }

        public void AddTotal(string name, string price)
        {
            OrderTotal newTotal = new OrderTotal('?');
            totales.Add(newTotal.GenerateTotal(name, price));
        }

        public void AddFooterLine(string line)
        {
            footerLines.Add(line);
        }

        private string AlignRightText(int lenght)
        {
            string espacios = "";
            int spaces = maxChar - lenght;
            for (int x = 0; x < spaces; x++)
                espacios += " ";
            return espacios;
        }

        private string DottedLine()
        {
            string dotted = "";
            for (int x = 0; x < maxChar; x++)
                dotted += "=";
            return dotted;
        }

        public bool PrinterExists(string impresora)
        {
            foreach (String strPrinter in PrinterSettings.InstalledPrinters)
            {
                if (impresora == strPrinter)
                    return true;
            }
            return false;
        }

        public void PrintTicket(string impresora)
        {
            printFont = new Font(fontName, fontSize, FontStyle.Regular);
            PrintDocument pr = new PrintDocument();
            pr.PrinterSettings.PrinterName = impresora;
            pr.PrintPage += new PrintPageEventHandler(pr_PrintPage);
            pr.Print();
        }

        private void pr_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.PageUnit = GraphicsUnit.Millimeter;
            gfx = e.Graphics;

            DrawImage();
            DrawHeader();
            DrawSubHeader();
            DrawItems();
            DrawTotales();
            DrawFooter();

            if (headerImage != null)
            {
                HeaderImage.Dispose();
                headerImage.Dispose();
            }
        }

        private float YPosition()
        {
            return topMargin + (count * printFont.GetHeight(gfx) + imageHeight);
        }

        private void DrawImage()
        {
            if (headerImage != null)
            {
                try
                {
                    gfx.DrawImage(headerImage, new Point((int)leftMargin, (int)YPosition()));
                    double height = ((double)headerImage.Height / 58) * 15;
                    imageHeight = (int)Math.Round(height) + 3;
                }
                catch (Exception)
                {
                }
            }
        }

        private void DrawHeader()
        {
            foreach (string header in headerLines)
            {
                if (header.Length > maxChar)
                {
                    int currentChar = 0;
                    int headerLenght = header.Length;

                    while (headerLenght > maxChar)
                    {
                        line = header.Substring(currentChar, maxChar);
                        gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                        count++;
                        currentChar += maxChar;
                        headerLenght -= maxChar;
                    }
                    line = header;
                    gfx.DrawString(line.Substring(currentChar, line.Length - currentChar), printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                    count++;
                }
                else
                {
                    line = header;
                    gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                    count++;
                }
            }
            DrawEspacio();
        }

        private void DrawSubHeader()
        {
            line = DottedLine();

            gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

            count++;
            foreach (string subHeader in subHeaderLines)
            {
                if (subHeader.Length > maxChar)
                {
                    int currentChar = 0;
                    int subHeaderLenght = subHeader.Length;

                    while (subHeaderLenght > maxChar)
                    {
                        line = subHeader;
                        gfx.DrawString(line.Substring(currentChar, maxChar), printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                        count++;
                        currentChar += maxChar;
                        subHeaderLenght -= maxChar;
                    }
                    line = subHeader;
                    gfx.DrawString(line.Substring(currentChar, line.Length - currentChar), printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                    count++;
                }
                else
                {
                    line = subHeader;

                    gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                    count++;

                    
                }

            }
            line = DottedLine();

            gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

            count++;
            DrawEspacio();
        }

        private void DrawItems()
        {
            OrderItem ordIt = new OrderItem('?');

            switch (_venta)
            {
                case 0:
                    {
                        gfx.DrawString("CLAVE     INTERES    RECARGO       TOTAL", printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                        count++;
                        DrawEspacio();

                        foreach (string item in items)
                        {
                            string[] valores = item.Split(new[] {'?'});
                            line = valores[0] + valores[1].PadLeft(10)
                                + valores[2].PadLeft(11 )
                                + valores[3].PadLeft(12);
                            gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                            count++;
                             gfx.DrawString("MES: "+ valores[4], printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                        count++;
                        }

                        leftMargin = 0;
                        DrawEspacio();
                        line = DottedLine();

                        gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                        count++;
                        
                       
                        DrawEspacio();
                    } break;
                case 1:
                    {
                        gfx.DrawString("CLAVE  DESCRIPCION                PRECIO", printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                        count++;
                        DrawEspacio();

                        foreach (string item in items)
                        {
                            line = ordIt.GetItemCantidad(item);

                            gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                            line = ordIt.GetItemPrice(item);
                            line = AlignRightText(line.Length) + line;

                            gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                            string name = ordIt.GetItemName(item);

                            leftMargin = 0;
                            if (name.Length > maxCharDescription)
                            {
                                int currentChar = 0;
                                int itemLenght = name.Length;

                                while (itemLenght > maxCharDescription)
                                {
                                    line = ordIt.GetItemName(item);
                                    gfx.DrawString("      " + line.Substring(currentChar, maxCharDescription), printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                                    count++;
                                    currentChar += maxCharDescription;
                                    itemLenght -= maxCharDescription;
                                }

                                line = ordIt.GetItemName(item);
                                gfx.DrawString("      " + line.Substring(currentChar, line.Length - currentChar), printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                                count++;
                            }
                            else
                            {
                                gfx.DrawString("      " + ordIt.GetItemName(item), printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                                count++;
                            }
                        }

                        leftMargin = 0;
                        DrawEspacio();
                        line = DottedLine();

                        gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                        count++;
                        DrawEspacio();
                    } break;
                case 2:
                    {
                        gfx.DrawString("                CONCEPTO                ", printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                        count++;
                        DrawEspacio();
                        foreach (string item in items)
                        {
                            leftMargin = 0;
                            string name = ordIt.GetItemName(item);
                            if (name.Length > 40)
                            {
                                int currentChar = 0;
                                int itemLenght = name.Length;

                                while (itemLenght > 40)
                                {
                                    line = ordIt.GetItemName(item);
                                    gfx.DrawString(line.Substring(currentChar, 40), printFont, myBrush, leftMargin,
                                        YPosition(), new StringFormat());

                                    count++;
                                    currentChar += 40;
                                    itemLenght -= 40;
                                }
                                line = ordIt.GetItemName(item);
                                gfx.DrawString(line.Substring(currentChar, line.Length - currentChar), printFont,
                                    myBrush, leftMargin, YPosition(), new StringFormat());
                                count++;
                            }
                            else
                            {
                                gfx.DrawString(ordIt.GetItemName(item), printFont, myBrush, leftMargin,
                                    YPosition(), new StringFormat());

                                count++;
                            }
                        }
                        leftMargin = 0;
                        DrawEspacio();
                        line = DottedLine();

                        gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                        count++;
                        DrawEspacio();
                        
                    }
                    break;
                case 3:
                    {
                        gfx.DrawString("          ARTICULOS   VENDIDOS          ", printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                        count++;
                        DrawEspacio();
                        leftMargin = 0;
                        string name = ordIt.GetItemName(items[0].ToString());
                        if (name.Length > 40)
                        {
                            int currentChar = 0;
                            int itemLenght = name.Length;

                            while (itemLenght > 40)
                            {
                                line = ordIt.GetItemName(items[0].ToString());
                                gfx.DrawString(line.Substring(currentChar, 40), printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                                count++;
                                currentChar += 40;
                                itemLenght -= 40;
                            }

                            line = ordIt.GetItemName(items[0].ToString());
                            gfx.DrawString(line.Substring(currentChar, line.Length - currentChar), printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                            count++;
                        }
                        else
                        {
                            gfx.DrawString(ordIt.GetItemName(items[0].ToString()), printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                            count++;
                        }
                        leftMargin = 0;
                        DrawEspacio();
                        line = DottedLine();

                        gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                        count++;
                        DrawEspacio();

                    }
                    break;
                case 4:
                    {
                        gfx.DrawString("NUM            FECHA          TOTAL PAGO", printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                        count++;
                        DrawEspacio();

                        foreach (string item in items)
                        {
                            line = ordIt.GetItemCantidad(item);

                            gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                            line = ordIt.GetItemPrice(item);
                            line = AlignRightText(line.Length) + line;

                            gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                            string name = ordIt.GetItemName(item);

                            leftMargin = 0;
                            if (name.Length > maxCharDescription)
                            {
                                int currentChar = 0;
                                int itemLenght = name.Length;

                                while (itemLenght > maxCharDescription)
                                {
                                    line = ordIt.GetItemName(item);
                                    gfx.DrawString("      " + line.Substring(currentChar, maxCharDescription), printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                                    count++;
                                    currentChar += maxCharDescription;
                                    itemLenght -= maxCharDescription;
                                }

                                line = ordIt.GetItemName(item);
                                gfx.DrawString("      " + line.Substring(currentChar, line.Length - currentChar), printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                                count++;
                            }
                            else
                            {
                                gfx.DrawString("      " + ordIt.GetItemName(item), printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                                count++;
                            }
                        }

                        leftMargin = 0;
                        DrawEspacio();
                        line = DottedLine();

                        gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                        count++;
                        DrawEspacio();
                    } break;
                case 5:
                    {
                        gfx.DrawString("CANT      TIPO        PRECIO     IMPORTE", printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                        count++;
                        DrawEspacio();

                        foreach (string item in items)
                        {
                            string[] valores = item.Split(new[] { '?' });
                            line = valores[0].PadRight(10) + valores[1].PadRight(8)
                                + valores[2].PadLeft(10)
                                + valores[3].PadLeft(12);
                            gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                            count++;
                        }

                        leftMargin = 0;
                        DrawEspacio();
                        line = DottedLine();

                        gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                        count++;
                        DrawEspacio();
                    } break;
            }
            
        }

        private void DrawTotales()
        {
            OrderTotal ordTot = new OrderTotal('?');

            foreach (string total in totales)
            {
                line = ordTot.GetTotalCantidad(total);
                line = AlignRightText(line.Length) + line;

                gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                leftMargin = 0;

                line = "      " + ordTot.GetTotalName(total);
                gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                count++;
            }
            leftMargin = 0;
            DrawEspacio();
            DrawEspacio();
        }

        private void DrawFooter()
        {
            foreach (string footer in footerLines)
            {
                if (footer.Length > maxChar)
                {
                    int currentChar = 0;
                    int footerLenght = footer.Length;

                    while (footerLenght > maxChar)
                    {
                        line = footer;
                        gfx.DrawString(line.Substring(currentChar, maxChar), printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                        count++;
                        currentChar += maxChar;
                        footerLenght -= maxChar;
                    }
                    line = footer;
                    gfx.DrawString(line.Substring(currentChar, line.Length - currentChar), printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                    count++;
                }
                else
                {
                    line = footer;
                    gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                    count++;
                }
            }
            leftMargin = 0;
            DrawEspacio();
            DrawEspacio();
        }

        private void DrawEspacio()
        {
            line = "   ";

            gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

            count++;
        }
    }

    public class OrderItem
    {
        char[] delimitador = new char[] { '?' };

        public OrderItem(char delimit)
        {
            delimitador = new char[] { delimit };
        }

        public string GetItemCantidad(string orderItem)
        {
            string[] delimitado = orderItem.Split(delimitador);
            return delimitado[0];
        }

        public string GetItemName(string orderItem)
        {
            string[] delimitado = orderItem.Split(delimitador);
            return delimitado[1];
        }

        public string GetItemPrice(string orderItem)
        {
            string[] delimitado = orderItem.Split(delimitador);
            return delimitado[2];
        }

        public string GenerateItem(string cantidad, string itemName, string price)
        {
            return cantidad + delimitador[0] + itemName + delimitador[0] + price;
        }
        public string GenerateItem(string cvepago, string interes, string recargo, string total,string mes)
        {
            return cvepago + delimitador[0] + interes + delimitador[0] + recargo + delimitador[0] + total + delimitador[0] + mes;
        }
    }

    public class OrderTotal
    {
        char[] delimitador = new char[] { '?' };

        public OrderTotal(char delimit)
        {
            delimitador = new char[] { delimit };
        }

        public string GetTotalName(string totalItem)
        {
            string[] delimitado = totalItem.Split(delimitador);
            return delimitado[0];
        }

        public string GetTotalCantidad(string totalItem)
        {
            string[] delimitado = totalItem.Split(delimitador);
            return delimitado[1];
        }

        public string GenerateTotal(string totalName, string price)
        {
            return totalName + delimitador[0] + price;
        }
    }
}
