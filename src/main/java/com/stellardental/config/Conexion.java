package com.stellardental.config;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class Conexion {
    private static final String URL = "jdbc:postgresql://aws-1-us-east-1.pooler.supabase.com:6543/postgres";
    private static final String USER = "postgres.bpraqfhffmcqjsxbcrzb";
    private static final String PASSWORD = getPassword();

    static {
        try {
            Class.forName("org.postgresql.Driver");
        } catch (ClassNotFoundException e) {
            throw new ExceptionInInitializerError(e);
        }
    }

    public static Connection getConnection() throws SQLException {
        return DriverManager.getConnection(URL, USER, PASSWORD);
    }

    private static String getPassword() {
        String envPassword = System.getenv("SUPABASE_PASSWORD");
        if (envPassword != null && !envPassword.isBlank()) {
            return envPassword;
        }
        return "BpNWq_j9QjZ#%zs";
    }
}
