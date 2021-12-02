DB_USER=QySinDbUser
DB_NAME=QySinDb
HOST=192.168.1.250

psql -U $DB_USER -d $DB_NAME -h $HOST -f cleanup.sql
psql -U $DB_USER -d $DB_NAME -h $HOST -f types.sql
psql -U $DB_USER -d $DB_NAME -h $HOST -f tables.sql
psql -U $DB_USER -d $DB_NAME -h $HOST -f views.sql
psql -U $DB_USER -d $DB_NAME -h $HOST -f seed.sql