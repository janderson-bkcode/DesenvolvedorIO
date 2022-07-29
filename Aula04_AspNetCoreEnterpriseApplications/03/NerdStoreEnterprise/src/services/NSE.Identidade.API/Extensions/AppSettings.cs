namespace NSE.Identidade.API.Extensions
    {/// <summary>
    /// Classe que representa os dados do Token e será guardado no arquivo appSettings.json
    /// </summary>
    public class AppSettings
    {
        //Chave
        public string Secret { get; set; }

        //Tempo que token será valido e expiração
        public int ExpiracaoHoras { get; set; }

        //Issuer
        public string Emissor { get; set; }

        //Audience
        public string ValidoEm { get; set; }

    }
}
