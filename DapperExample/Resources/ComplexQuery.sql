SELECT
    d1."ID" AS "IDTable1",
    d1."Col1" AS "Col1Table1",
    d1."Col2" AS "Col2Table1",
    d2."ID" AS "IDTable2",
    d2."Col1" AS "Col1Table2",
    d2."Col2" AS "Col2Table2"
FROM "DapperTestTable1" d1
INNER JOIN "DapperTestTable2" d2 on d1."ID" = d2."ID"
WHERE d1."ID" = @ID