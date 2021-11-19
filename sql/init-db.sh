DB_USER=QySinDbUser
DB_NAME=QySinDb
HOST=127.0.0.1

psql -U $DB_USER -d $DB_NAME -h $HOST -f cleanup.sql
psql -U $DB_USER -d $DB_NAME -h $HOST -f types.sql
psql -U $DB_USER -d $DB_NAME -h $HOST -f tables.sql
psql -U $DB_USER -d $DB_NAME -h $HOST -f seed.sql