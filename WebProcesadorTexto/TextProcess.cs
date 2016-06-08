using System;
using System.Collections.Generic;
public enum SilabaF { N, C, V, CV, CC, VN, VV, VC, VVC, CVC, CVV, CCV, CVVC, CVVV, CCVV, CCVC, CVVVC, CCVVC, CCVVCC };

public class TextProcess
{
    private static char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
    
    private String miTexto { get; set; }
    public TextProcess()
    {
        this.miTexto = "";

    }
    public TextProcess(String miTexto)
    {
        if (miTexto == null || miTexto == "")
            throw new Exception("There is no text to be proccess");
        
        this.miTexto = miTexto;
    }
    public void setTexto(String miTexto="")
    {
        this.miTexto = miTexto;
        
    }
    public String ProcesarTexto(int nMaxChar)
    {
        string container="";
        int length=0;
        int spacepos=-1;
        if (this.miTexto == "")
            throw new Exception("There is no text to be proccess");
        if (nMaxChar <= 0)
            throw new Exception("There nMaxChar can't be 0 or less");
        
        while ((miTexto.Length- length) > nMaxChar)
        {
            
            spacepos = miTexto.Substring(length, nMaxChar+1).LastIndexOf(" ")+1;//cuando tenemos una palabra de la misma longitud, nos saltamos el espacio
            if (spacepos == 0)
            {  
                spacepos=getToCut(nMaxChar, length);// desde length 
               // spacepos =(spacepos == -1)?nMaxChar:spacepos;
                container = container + miTexto.Substring(length, spacepos).Trim() + (miTexto.Substring(length, spacepos).Trim().Length != 0 ? "-\n" : "");
                length += spacepos;
            }
            else
            {
                container = container + miTexto.Substring(length, spacepos).Trim() + (miTexto.Substring(length, spacepos).Trim().Length != 0 ? "\n" : "");
                length += spacepos;

            }
        }
        container = container + miTexto.Substring(length, miTexto.Length - length).Trim();
        return container;
    }
    public int getToCut(int nMaxChar, int length)
    {   
        if (nMaxChar == 1)
            return nMaxChar;
        int suma = 0;
        int primerEspacio = miTexto.Substring(length).LastIndexOf(" ", nMaxChar) + 1+length;
        int corte = -primerEspacio+ miTexto.IndexOf(" ", primerEspacio) + 1;
        String word = miTexto.Substring(primerEspacio, (corte <= 0 ? (miTexto.Substring(primerEspacio).Length) : (corte)));
        int[] posSilaba = getSilabas(word.Trim());
        for (int i = 0; i < posSilaba.Length; i++)
        {
            suma += posSilaba[i];
            if (posSilaba[i]==-1)
            {
                return nMaxChar - 1;
            }
            else if (suma > nMaxChar-1 && i != 0)
                return suma -posSilaba[i];
            else if (suma > nMaxChar-1 && i == 0)
            {
                return nMaxChar-1;
            }
            
        }

        return posSilaba[posSilaba.Length - 1];

    }

    public int[] getSilabas(String word)
    {   
        String l1;
        String l2;
        int cut=-1;
        List<int> lista = new List<int>();
        while ((word.Length)>0)
        {
            l1= word.Substring(0,1);

            if (isVocal(l1))
            {
                cut = caso_1(word);
                if (cut == -1)
                {
                    lista.Add(-1);
                    return lista.ToArray();
                }
                else
                {
                    lista.Add(cut);
                    word = word.Substring(cut);
                }
             }
            else {
                l2 = Substring(word, 1, 1);
                if (isVocal(l2))
                {
                    cut = caso_2(word);
                    if (cut == -1)
                    {
                        lista.Add(-1);
                        return lista.ToArray();
                    }
                    else
                    {
                        lista.Add(cut);
                        word = word.Substring(cut);
                    }
                }
                else
                {
                    cut = caso_3(word);
                    if (cut == -1)
                    {
                        lista.Add(-1);
                        return lista.ToArray();
                    }
                    else
                    {
                        lista.Add(cut);
                        word = word.Substring(cut);

                    }


                }
            }

        }
        return lista.ToArray();
    }
    public int caso_1(string word)
    {
        SilabaF[] tA =  { SilabaF.N, SilabaF.CV, SilabaF.CCV, SilabaF.VN};
        SilabaF[] tB =  { SilabaF.N, SilabaF.CV, SilabaF.CCV};
        if (word == null)
            throw new ArgumentNullException();
        if (word.Length == 1)
            return 1;
        if (wichterminacion(word.Substring(1), tA))
            return 1;
        else if (!isVocal(Substring(word, 1,1)))
        {
            if (wichterminacion(Substring(word, 2), tB))
            {
                return 2;
            }
            else
                return -1;
        }
        else if (isVocal(Substring(word, 1, 1)))

        {
            if (wichterminacion(Substring(word, 2), tB))
                return 2;
            else if (!isVocal(Substring(word, 2, 1)))
                if (wichterminacion(Substring(word, 3), tB))
                    return 3;
            
        }
         
        return -1;
    }
    public int caso_2(string word)
    {
        SilabaF[] tA = { SilabaF.N, SilabaF.CV, SilabaF.CCV };
        SilabaF[] tB = { SilabaF.N, SilabaF.CV };
        if (word == null)
            throw new ArgumentNullException();
        if (word.Length == 1)
            return 1;
        if (wichterminacion(word.Substring(2), tA))
            return 2;
        else if (!isVocal(Substring(word, 2, 1)))
        {
            if (wichterminacion(Substring(word, 3), tA))
            {
                return 3;
            }
            else if (!isVocal(Substring(word, 2, 1)))
            {
                if (wichterminacion(Substring(word, 4), tB))
                {
                    return 4;
                }

            }

        }
        else if (wichterminacion(Substring(word, 3), tA))
            return 3;
        else if (!isVocal(Substring(word, 3, 1)))
        {
            if (wichterminacion(Substring(word, 4), tA))
                return 4;
        }
        else if (wichterminacion(Substring(word, 4), tA))
            return 4;
        else if (!isVocal(Substring(word, 4, 1)))
            if (wichterminacion(Substring(word, 5), tA))
                return 5;
        

        return -1;
    }
    public int caso_3(string word) 
    {
        SilabaF[] tA = { SilabaF.N, SilabaF.CV, SilabaF.CCV };
        SilabaF[] tB = { SilabaF.N, SilabaF.CV };
        if (word == null)
            throw new ArgumentNullException();
        if (word.Length == 1)
            return 1;
        if (word.Length == 2)
            return 2;
        if (wichterminacion(word.Substring(3), tA))
        {

            return 3;
        }
        else if (!isVocal(Substring(word, 3, 1)))
        {
            if (wichterminacion(Substring(word, 4), tA))
            {
                return 4;
            }
            else if (wichterminacion(Substring(word, 5), tB))
                return 5;
        }
        else if (wichterminacion(Substring(word, 4), tA))
            return 4;
     
        else if (wichterminacion(Substring(word, 5), tA))
            return 5;


        return -1;
    }
    public bool isVocal(string c) {
        if (c.Length > 1)
            throw new Exception("The argument is too big.");
        string vocals = "aeiouáéíóú";
        if(vocals.IndexOf(c)!=-1)
                return true;
    
        return false;
    }
    public bool isCinseparable(string s)
    {
        if (s.Length > 2)
            throw new Exception("The argument is too big.");
        string[] cinseparables = { "br","bl","cr","cl","dr", "fr", "fl", "gr", "gl", "kr", "ll", "pr", "pl", "tr","rr","ch" };
        foreach (string j in cinseparables)
        {
            if (s == j)
                return true;
        }

        return false;
    }
    public bool wichterminacion(string s,SilabaF[] silabaF)
    {
     
        foreach (SilabaF c in silabaF)
        {
            if(wichterminacion(s,c))
                return true;
        }

        return false;
    }
   
    private bool wichterminacion(string s,SilabaF silabaF)
    { 
        switch (silabaF)
        {
            case SilabaF.N:
                if (s.Length < 1)
                    return true;
                break;
            case SilabaF.V:
                if (s.Length >= 1&& isVocal(s.Substring(0,1)))
                    return true;
                break;
            case SilabaF.C:
                if (s.Length >= 1 && !isVocal(s.Substring(0, 1)))
                    return true;
                break;
            case SilabaF.VC:
                if (s.Length >= 2 && isVocal(s.Substring(0, 1)) && !isVocal(s.Substring(1, 1)))
                    return true;
                break;
            case SilabaF.VV:
                if (s.Length >= 2 && isVocal(s.Substring(0, 1)) && isVocal(s.Substring(1, 1)))
                    return true;
                break;
            case SilabaF.CV:
                if (s.Length >= 2 && !isVocal(s.Substring(0, 1)) && isVocal(s.Substring(1, 1)))
                    return true;
                break;
            case SilabaF.CC:
                if (s.Length >= 2 && !isVocal(s.Substring(0, 1)) && !isVocal(s.Substring(1, 1)))
                    return true;
                break;
            case SilabaF.CCV:
                if (s.Length >= 3 && isCinseparable(s.Substring(0, 2))&& isVocal(s.Substring(2, 1)))
                    return true;
                break;
            case SilabaF.CVC:
                if (s.Length >= 3 && !isVocal(s.Substring(0, 1)) && isVocal(s.Substring(1, 1)) && !isVocal(s.Substring(2, 1)))
                    return true;
                break;
            case SilabaF.CVV:
                if (s.Length >= 3 && !isVocal(s.Substring(0, 1)) && isVocal(s.Substring(1, 1)) && isVocal(s.Substring(2, 1)))
                    return true;
                break;
            case SilabaF.VVC:
                if (s.Length >= 3 && isVocal(s.Substring(0, 1)) && isVocal(s.Substring(1, 1)) && !isVocal(s.Substring(2, 1)))
                    return true;
                break;
            case SilabaF.CCVC:
                if (s.Length >= 4 && !isVocal(s.Substring(0, 1)) && !isVocal(s.Substring(1, 1)) && isVocal(s.Substring(2, 1))&& !isVocal(s.Substring(3, 1)))
                    return true;
                break;
            case SilabaF.CCVV:
                if (s.Length >= 4 && !isVocal(s.Substring(0, 1)) && !isVocal(s.Substring(1, 1)) && isVocal(s.Substring(2, 1)) && isVocal(s.Substring(3, 1)))
                    return true;
                break;
            case SilabaF.CVVC:
                if (s.Length >= 4 && !isVocal(s.Substring(0, 1)) && isVocal(s.Substring(1, 1)) && isVocal(s.Substring(2, 1)) && !isVocal(s.Substring(3, 1)))
                    return true;
                break;
            case SilabaF.CVVV:
                if (s.Length >= 4 && isVocal(s.Substring(0, 1)) && isVocal(s.Substring(1, 1)) && isVocal(s.Substring(2, 1)) && !isVocal(s.Substring(3, 1)))
                    return true;
                break;
            case SilabaF.CCVVC:
                if (s.Length >= 5 && !isVocal(s.Substring(0, 1)) && !isVocal(s.Substring(1, 1)) && isVocal(s.Substring(2, 1)) && isVocal(s.Substring(3, 1)) && !isVocal(s.Substring(4, 1)))
                    return true;
                break;
            case SilabaF.CVVVC:
                if (s.Length >= 5 && !isVocal(s.Substring(0, 1)) && isVocal(s.Substring(1, 1)) && isVocal(s.Substring(2, 1)) && isVocal(s.Substring(3, 1)) && !isVocal(s.Substring(4, 1)))
                    return true;
                break;
            case SilabaF.CCVVCC:
                if (s.Length >= 6 && !isVocal(s.Substring(0, 1)) && !isVocal(s.Substring(1, 1)) && isVocal(s.Substring(2, 1)) && isVocal(s.Substring(3, 1)) && !isVocal(s.Substring(4, 1)) && !isVocal(s.Substring(5, 1)))
                    return true;
                break;
            default:
                return false;
        }

        return false;

    }

    public string Substring(string value, int startIndex, int length=0)
    {
        if (value.Length == 0)
            return "";
        if (length == 0)
            length=value.Length - startIndex;
        if (value.Length <= (startIndex))
            return "";
        if (value.Length < (startIndex+length))
           return value.Substring(startIndex, value.Length - startIndex-1);
        return value.Substring(startIndex, length);
    }
}
