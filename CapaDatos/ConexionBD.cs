namespace CapaDatos
{
    public static class ConexionBD
    {
        public static string CadenaConexion { get; } =
            "Host=aws-1-us-east-1.pooler.supabase.com;" +
            "Port=6543;" +
            "Database=postgres;" +
            "Username=postgres.bpraqfhffmcqjsxbcrzb;" +
            "Password=BpNWq_j9QjZ#%zs;" +
            "SslMode=Require;" +
            "Pooling=false;" +
            "Timeout=15;" +
            "KeepAlive=30;";
    }
}
