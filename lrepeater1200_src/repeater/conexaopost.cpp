#include "conexaopost.h"
#include <string>
#include "libpq-fe.h"
#include "repeater.h"
#include <sstream>
#include <string.h>


PGconn *conn = PQconnectdb("user=postgres password=thiago dbname=suporteremoto hostaddr=186.202.116.166 port=5432");
void CloseConn()
{
	PQfinish(conn);
	getchar();
	exit(1);
}
//
///* Establish connection to database */
void ConnectDB()
{
	if (PQstatus(conn) != CONNECTION_OK)
	{
		printf("Connection to database failed");
		CloseConn();
	}

	printf("Connection to database - OK\n");

}

void atualizacliente(char *status, const char *id)
{

	ConnectDB();
	std::string sSQL;
	sSQL.append("update cliente set clie_status = ");
	sSQL.append(status);
	sSQL.append(" where clie_idvnc =");
	sSQL.append(id);

	PGresult *res = PQexec(conn, sSQL.c_str());

	if (PQresultStatus(res) != PGRES_COMMAND_OK)
	{
		PQclear(res);
		CloseConn();
	}
	PQclear(res);
}

void atualizacliente1()
{
	ConnectDB();
	std::string sSQL;
	sSQL.append("update cliente set clie_status = false ");

	PGresult *res = PQexec(conn, sSQL.c_str());

	if (PQresultStatus(res) != PGRES_COMMAND_OK)
	{
		PQclear(res);
		CloseConn();
	}
	PQclear(res);
}

void nemusocliente()
{
	ConnectDB();
	std::string sSQL;
	sSQL.append("update cliente set clie_emuso = false ");

	PGresult *res = PQexec(conn, sSQL.c_str());

	if (PQresultStatus(res) != PGRES_COMMAND_OK)
	{
		PQclear(res);
		CloseConn();
	}
	PQclear(res);
}

void emusocliente(char *status, const char *id)
{
	ConnectDB();
	std::string sSQL;
	sSQL.append("update cliente set clie_emuso = ");
	sSQL.append(status);
	sSQL.append(" where clie_idvnc =");
	sSQL.append(id);

	PGresult *res = PQexec(conn, sSQL.c_str());

	if (PQresultStatus(res) != PGRES_COMMAND_OK)
	{
		PQclear(res);
		CloseConn();
	}
	PQclear(res);
}


void lerclientes()
{
	int i;
	atualizacliente1();
	nemusocliente();
	for (i = 0; i<MAX_LIST; i++)
	{
		if (Servers[i].code != 0)
		{
			std::string numStr = std::to_string(Servers[i].code);
			const char* cod = numStr.c_str();
			atualizacliente("true", cod);

			if (Servers[i].used == 1)
			{
				emusocliente("true", cod);
			}
		}
	}

}
