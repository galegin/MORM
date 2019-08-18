private void dropColumn(SQLiteDatabase db,
        ConnectionSource connectionSource,
        String createTableCmd,
        String tableName,
        String[] colsToRemove) throws java.sql.SQLException {

    List<String> updatedTableColumns = getTableColumns(tableName);
    // Remove the columns we don't want anymore from the table's list of columns
    updatedTableColumns.removeAll(Arrays.asList(colsToRemove));

    String columnsSeperated = TextUtils.join(",", updatedTableColumns);

    db.execSQL("ALTER TABLE " + tableName + " RENAME TO " + tableName + "_old;");

    // Creating the table on its new format (no redundant columns)
    db.execSQL(createTableCmd);

    // Populating the table with the data
    db.execSQL("INSERT INTO " + tableName + "(" + columnsSeperated + ") SELECT "
            + columnsSeperated + " FROM " + tableName + "_old;");
    db.execSQL("DROP TABLE " + tableName + "_old;");
}

public List<String> getTableColumns(String tableName) {
    ArrayList<String> columns = new ArrayList<String>();
    String cmd = "pragma table_info(" + tableName + ");";
    Cursor cur = getDB().rawQuery(cmd, null);

    while (cur.moveToNext()) {
        columns.add(cur.getString(cur.getColumnIndex("name")));
    }
    cur.close();

    return columns;
}

pragma table_info("empresa");

SELECT sql FROM sqlite_master WHERE name='empresa';

ALTER TABLE empresa RENAME TO empresa_old;

CREATE TABLE "EMPRESA"(
"ID_EMPRESA" Integer PRIMARY KEY  NOT NULL,
"U_VERSION" Text,
"CD_OPERADOR" Integer NOT NULL,
"DT_CADASTRO" Text NOT NULL,
"ID_GRUPOEMPRESA" integer NOT NULL,
"CD_EMPRESA" text NOT NULL,
"DS_EMPRESA" text NOT NULL,
"ID_PESSOA" Text
)

ID_EMPRESA,U_VERSION,CD_OPERADOR,DT_CADASTRO,ID_GRUPOEMPRESA,CD_EMPRESA,DS_EMPRESA,ID_PESSOA

INSERT INTO empresa (ID_EMPRESA,U_VERSION,CD_OPERADOR,DT_CADASTRO,ID_GRUPOEMPRESA,CD_EMPRESA,DS_EMPRESA,ID_PESSOA) 
SELECT ID_EMPRESA,U_VERSION,CD_OPERADOR,DT_CADASTRO,ID_GRUPOEMPRESA,CD_EMPRESA,DS_EMPRESA,ID_PESSOA
FROM empresa_old

drop table empresa_old