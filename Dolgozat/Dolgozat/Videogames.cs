class Videogames
{
    public string Cim { get; set; }
    public string Mufaj { get; set; }
    public DateTime KiadasDatum { get; set; }
    public int AktivJatekosok { get; set; }
    public float Ertekeles { get; set; }

    public override string ToString() =>
        $"\tCim:             {Cim}\n" +
        $"\tMűfaj:           {Mufaj}\n" +
        $"\tKiadás dátuma:   {KiadasDatum}" +
        $"\tAktív játékosok: {AktivJatekosok}" +
        $"\tÉrtékelés:       {Ertekeles:0.0}";

}       

