/* wsfdata.h
 * 
 * This file was created by an automated utility. 
 * It is not intended for manual editing
 */

extern em_file efslist[37];

extern  unsigned char index_html1[1351];
extern  unsigned char passwd_html2[1396];
extern  unsigned char settings_html3[3300];
extern  unsigned char ok_html4[527];
extern  unsigned char nok_html5[542];
extern  unsigned char log_html6[886];
extern  unsigned char comment_html7[1943];
extern  unsigned char images2_jpg8[10130];
extern  unsigned char connections_txt9[39];
extern  unsigned char viewer_access_txt10[41];
extern  unsigned char server_access_txt11[41];

int     memory_ssi(wi_sess * sess, EOFILE * eofile);

int     mode1_ssi(wi_sess * sess, EOFILE * eofile);

int     mode2_ssi(wi_sess * sess, EOFILE * eofile);

int     sport_ssi(wi_sess * sess, EOFILE * eofile);

int     vport_ssi(wi_sess * sess, EOFILE * eofile);

int     acon_ssi(wi_sess * sess, EOFILE * eofile);

int     rcon_ssi(wi_sess * sess, EOFILE * eofile);

int     aid_ssi(wi_sess * sess, EOFILE * eofile);

int     acons_ssi(wi_sess * sess, EOFILE * eofile);

int     rcons_ssi(wi_sess * sess, EOFILE * eofile);

int     aids_ssi(wi_sess * sess, EOFILE * eofile);

int     webport_ssi(wi_sess * sess, EOFILE * eofile);

int     log_ssi(wi_sess * sess, EOFILE * eofile);

int     ucom_ssi(wi_sess * sess, EOFILE * eofile);

int     listcomment_ssi(wi_sess * sess, EOFILE * eofile);

int     connections_ssi(wi_sess * sess, EOFILE * eofile);

int     server_access_ssi(wi_sess * sess, EOFILE * eofile);

int     viewer_access_ssi(wi_sess * sess, EOFILE * eofile);

int     pushtest_func(wi_sess * sess, EOFILE * eofile);

char *  testaction_cgi(wi_sess * sess, EOFILE * eofile);

char *  testaction2_cgi(wi_sess * sess, EOFILE * eofile);

char *  testaction3_cgi(wi_sess * sess, EOFILE * eofile);

char *  testaction4_cgi(wi_sess * sess, EOFILE * eofile);

char *  testaction5_cgi(wi_sess * sess, EOFILE * eofile);

char *  passwd_cgi(wi_sess * sess, EOFILE * eofile);


#define  MEMHITS_VAR30                    30


