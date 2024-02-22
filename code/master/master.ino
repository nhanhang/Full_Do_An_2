//khung truyen @+diachigui+maham+bytedata+crc+diachinhan#
//dia chi: A-master B-slave1 C-slave2 D-pc
//ma ham: 0-send 1-receive_success 2-receive_failure 
#include <DFRobot_ESP_EC.h>
#include <stdio.h>
#include <stdlib.h>
#include "DHT.h"
#include <HardwareSerial.h>
#include <string.h>

HardwareSerial SerialPort(2);  // use UART2

#define led1 2
#define led2 4
#define tem_pin 27
#define ec_pin 33
#define De 19
#define Re 18
String start, address_receive, address_sent, data, function, crc, length_data, Ec_str, Tem_str, pack, End;
char warring[12] = "@DE5017682#";

unsigned long per_time;
unsigned long t_time;
unsigned long r_time;
int opp=0, ieu=0;
int npk=0, ijk=0;
int ec1=0, ec2=0, h1=0, h2=0;
int result = 0; //1-success 2-failure
int chedo= 1; //0-allow 1-unallow
int dem=0;
int kieutruyen=0;
int tg=0;
char* checkwr;
float DHTPIN = tem_pin;
const int DHTTYPE = DHT22;
DHT dht(DHTPIN, DHTTYPE);
void reset(){
  start="";
  address_receive="";
  address_sent="";
   data="";
  function="";
  length_data="";
  Ec_str="";
  Tem_str="";
  pack="";
 End="";
}
int chuyen1(String a) {
  int l1 = a.length();
  int num = 0;
  for (int i = l1 - 1; i >= 0; --i) {
    num += (int)(a[i] - '0') * pow(10, l1 - i - 1);
  }
  return num+48;
}
int chuyen(String a) {
  int l1 = a.length();
  int num = 0;
  for (int i = l1 - 1; i >= 0; --i) {
    num += (int)(a[i] - '0') * pow(10, l1 - i - 1);
  }
  return num;
}
int xorbyte(String a, int crc) {
  int b = chuyen1(a);
  //int dem=0;
  crc = crc ^ b;
  int tt;
  for (int i = 0; i < 8; i++)
    if (crc & 0x0001) {
      crc = crc >> 1;

      crc = crc ^ 0xA001;
    } else {
      crc= crc >> 1;
    }
  return crc;
}

int value_crc2(String address_sent2, String address_receive2, String funcion2, String length_data2) {
  int length = chuyen(length_data2);
  String k;
  int crc = 0xFFFF;
  int cl;

  crc = xorbyte(address_sent2, crc);
  crc = xorbyte(address_receive2, crc);
  crc = xorbyte(funcion2, crc);
  crc = xorbyte(length_data2, crc);
   
  return crc;
}
int value_crc(String address_sent2, String address_receive2, String funcion2, String length_data2, String data2) {
  int length1 = chuyen(length_data2);
  
  String k;
  int crc = 0xFFFF;
  int cl;

  crc = xorbyte(address_sent2, crc);
  crc = xorbyte(address_receive2, crc);
  crc = xorbyte(funcion2, crc);
  crc = xorbyte(length_data2, crc);
    for (int i = 0; i < length1; i ++ ) {
      k = data2.substring(i, i + 1);
      crc=xorbyte(k, crc);
    }
    
  return crc;
}
int value_crc1(String address_sent2, String address_receive2, String funcion2, String length_data2, String data2, String length_data3, String data3) {
  int length1 = chuyen(length_data2);
  int length2 = chuyen(length_data3);
  String k;
  int crc = 0xFFFF;
  int cl;

  crc = xorbyte(address_sent2, crc);
  crc = xorbyte(address_receive2, crc);
  crc = xorbyte(funcion2, crc);
  crc = xorbyte(length_data2, crc);
    for (int i = 0; i < length1; i ++ ) {
      k = data2.substring(i, i + 1);
      crc=xorbyte(k, crc);
    }
    crc=xorbyte(length_data3,crc);
    for (int i = 0; i < length2; i ++ ) {
      k = data3.substring(i, i + 1);
      crc=xorbyte(k, crc);
    }
  return crc;
}

void boctach(String dl, int length) {
  int value_length;
  int length_rs485 = dl.length();
  start = dl.substring(0, 1);
  address_sent = dl.substring(1, 2);
  address_receive = dl.substring(2, 3);
  function = dl.substring(3, 4);
  length_data = dl.substring(4, 5);
  value_length = chuyen(length_data);
 if(value_length==0){
    crc=dl.substring(5,length_rs485-1);
     //Serial.println(crc);
  }
  else {
  
  data = dl.substring(5,5+value_length);
  crc = dl.substring(5 + value_length, length_rs485- 1);
  }
  End = dl.substring(length_rs485 - 1, length_rs485);
}
void boctach1(String dl, int length) {
  int value_length;
  int length_rs485 = dl.length();
  length_rs485=length_rs485/2;
  start = dl.substring(0, 1);
  address_sent = dl.substring(1, 2);
  address_receive = dl.substring(2, 3);
  function = dl.substring(3, 4);
  length_data = dl.substring(4, 5);
  value_length = chuyen(length_data);
 if(value_length==0){
    crc=dl.substring(5,length_rs485-1);
     //Serial.println(crc);
  }
  else {
  
  data = dl.substring(5,5+value_length);
  crc = dl.substring(5 + value_length, length_rs485- 1);
  }
  End = dl.substring(length_rs485 - 1, length_rs485);
}

void yeucaudoc(String address_gui, String address_nhan){
   digitalWrite(De,1);
     digitalWrite(Re,1);
String str_crc=""; 
int crc_ph = value_crc(address_gui, address_nhan, "3","0","");
str_crc.concat(crc_ph);
String pack_yeucau;
pack_yeucau= "@" + address_gui + address_nhan + "3"+ "0" + str_crc + "#";
Serial2.print(pack_yeucau);
Serial.println(pack_yeucau);
}


void phanhoidung(String address_gui, String address_nhan){
  digitalWrite(De,1);
    digitalWrite(Re,1);
String str_crc=""; 
int crc_ph = value_crc(address_gui, address_nhan, "1","0","");
str_crc.concat(crc_ph);
String pack_phd;
pack_phd= "@" + address_gui + address_nhan + "1"+ "0" + str_crc + "#";
Serial2.print(pack_phd);
//Serial.println(pack_phd);
 result=0;
}


void phanhoisai(String address_gui, String address_nhan){
   digitalWrite(De,1);
    digitalWrite(Re,1);
String str_crc=""; 
int crc_ph = value_crc(address_gui, address_nhan, "2","0","");
str_crc.concat(crc_ph);
String pack_phs;
pack_phs= "@" + address_gui + address_nhan + "2"+ "0" + str_crc + "#";
Serial2.print(pack_phs);
 //Serial.println(pack_phs);
 result=0;
}

void guidata(int value_ec, int value_humi, int value_ec2, int value_humi2,String address_gui, String address_nhan){
String str_ec1="";
String str_humi1="";
String str_ec2="";
String str_humi2="";
String str_crc="";
String str_length1="";
String str_length2="";
String str_length,data3;
str_ec1.concat(value_ec);
str_humi1.concat(value_humi);
str_ec2.concat(value_ec2);
str_humi2.concat(value_humi2);
String data1,data2;
data1=str_humi1 + str_ec1;
//Serial.println(data1);
data2=str_humi2 + str_ec2;
//Serial.println(data1);
int length_data1,crc1,length_data2;
length_data1=data1.length();
length_data2=data2.length();
str_length1.concat(length_data1);
str_length2.concat(length_data2);
str_length=str_length1+str_length2;
data3=data1+data2;
crc1=value_crc1(address_gui,address_nhan,"0",str_length1,data1,str_length2,data2);
str_crc.concat(crc1);
String pack1;
pack1 = "@" + address_gui + address_nhan + "0" + str_length1 + data1 + str_length2 + data2 + str_crc + "#";
 
Serial2.print(pack1);
Serial.println(pack1);
}

void docdata() {
   
  String pack = "";
  while (Serial2.available()) {
    char c = (char)Serial2.read();
    
    pack +=c;
    //Serial.print(c);
    //Serial.print("");
    delay(5);
  }
  pack.trim();
  
  Serial.println(pack);
  // digitalWrite(De,1);
  //  digitalWrite(Re,1);
  
  if (pack != "") {
    int length = pack.length();
    char hihi[length+1];
    pack.toCharArray(hihi,length+1);
    checkwr = strstr(hihi,warring);
  if(checkwr!=NULL){
    pack = "@DE5017682#";
  }
      int real_crc;
       int value_length;
       if(dem==2){
         boctach1(pack, length);
         
       }
       else {
         boctach(pack, length);
       }
       dem=0;
       //Serial.println( length);
    
    if(start=="@"&&End=="#"){
      value_length = chuyen(length_data);
     if(value_length==0){
        real_crc = value_crc2(address_sent, address_receive, function, length_data);
      }
      else {
    real_crc = value_crc(address_sent, address_receive, function, length_data, data);}
    int crc_pack = chuyen(crc);
    //Serial.println(real_crc);
    if(real_crc == crc_pack){
      
      if(function=="0"&&address_receive=="A"){
        //Serial.println(data);
      int length1_data = chuyen(length_data);
      
      if(address_sent=="B"){
        if (length1_data>4){
      Tem_str=data.substring(0,4);
      Ec_str=data.substring(4,length1_data);}
      else {
        Tem_str="0";
        Ec_str="0";
      }
      //Serial.println(Ec_str);
      ec1= chuyen(Ec_str);
      h1= chuyen(Tem_str);
     // guidata(ec1, h1, ec2, h2, "A", "D");
//Serial.println("hehe");
delay(300);
       phanhoidung("A","B");
       tg=1;
       opp=1;
       t_time=millis();
      // delay(200);
       //chedo=0;
      }
      else if(address_sent=="C"){
        if (length1_data>4){
      Tem_str=data.substring(0,4);
      Ec_str=data.substring(4,length1_data);}
      else {
        Tem_str="0";
        Ec_str="0";
      }
      ec2= chuyen(Ec_str);
      h2= chuyen(Tem_str);
       delay(300);
      //tg=0;
       phanhoidung("A","C");
       tg=2;
       opp=1;
       t_time=millis();
       chedo=0;
      //  delay(300);
      }
      else;
    }
    
    // else if(function=="1" && address_sent=="A"){
    //   if(address_receive=="C"){
    //     chedo=0; // dao nguoc khi sang slave 2
    //   }
    //}
    else if(function=="2"){
      if(address_sent=="D"){
        if(address_receive=="A"){
          guidata(ec1, h1, ec2, h2, "A", "D");
        }
      }
    }
    // else if(function == "3"){
    //   if(address_sent == "D" && kieutruyen==1){
    //     delay(500);
    //     yeucaudoc("A",address_receive);
    //   }
    // }
    else if (address_sent == "D" && address_receive == "E"){
      if(function == "4"){
        chedo=1;
        result = 0;
        kieutruyen=0;
        tg=0;
        //opp=1;
        t_time=millis();
        r_time = millis();
        ieu=0;
        ijk=0;
      }
      else {
        
        kieutruyen=1;
      t_time=millis();
      }
    }
    else;
    }
    else {
      if(function=="0"&&address_receive=="A"){
        if(address_sent == "B"){
          delay(100);
         phanhoisai("A","B");
        }
        else if(address_sent == "C"){
          delay(100);
           phanhoisai("A","C");
        }
      }
      
    }
  //  Serial.print(real_crc);
  //    Serial.print(" ");
  //    Serial.print(crc_pack);
  }
  else result=0;
  }
  else result=0;
  pack = "";
}




void setup() {
  // put your setup code here, to run once:
  Serial.begin(115200);
  Serial2.begin(115200);
  pinMode(De, OUTPUT);
  pinMode(Re, OUTPUT);
  
      digitalWrite(De,0);
    digitalWrite(Re,0);
   delay(10);
   
   per_time = millis();
   t_time = millis();
   r_time = millis();
   Serial.println(r_time);
}
//const uint16_t buf="101556";
//int len=buf.length();

void loop() {
  //master

reset();

   if(millis()-per_time > 300){
     per_time = millis();
     if(ieu==0){
      Serial.println( millis()-r_time);
     if(millis()-r_time >= 5000 && kieutruyen==0 && ijk==0)
    {
//Serial.print("hihi");
      if (tg==0){
        delay(100);
        ec1=0; h1=0;
        yeucaudoc("A","C");
        delay(100);
        Serial.println("huhu");
        ijk=1;
        //ieu=1;
      }
    }
    if (millis()-r_time >= 10000 && kieutruyen==0 && ijk==1){
      if(tg==0){
        delay(100);
        yeucaudoc("A","D");
        delay(100);
        ec2=0; h2=0;
        Serial.println("haha");
        ieu=1;
      }
    }
    
    }
   if(millis()-t_time >5000  && tg!=0 && kieutruyen == 0){
     delay(100);
     if(opp==1){
     if(tg==1){
       delay(200);
     yeucaudoc("A","B");
     delay(200);
     opp=0;
     ec2=0; h2=0;
     chedo=0;
     }
     else if(tg==2){
       //Serial.println("hoho"); 
        goto AB;
       //yeucaudoc("A","C");
       //phanhoidung("A","B");
     }
     else;}
     else {
       delay(100);
       yeucaudoc("A","D");
       delay(100);
       tg=4;
       ijk=3;
       opp=1;
     Serial.println("hehee");
     }
     t_time=millis();
   }
   AC:
   //phanhoidung("A","B");
    //delay(50);
digitalWrite(De,0);
   digitalWrite(Re,0);
    docdata();
//    Serial.println(result);
    delay(100);
  //  result=1;
  //   if(result==1){
  //     if(kieutruyen==0){
  //     digitalWrite(De,1);
  //   digitalWrite(Re,1);
  //   //delay(200);
  // delay(500);
  //     phanhoidung("A","B");
  //   //   delay(2000);
  //   //delay(200);
  //    //guidata(ec1, h1, ec2, h2, "A", "D");
  //    chedo=0;
  //     }
  //    //result=2;
  //   }
  //   else if(result==2){
  //     if(kieutruyen==0){
  //     digitalWrite(De,1);
  //   digitalWrite(Re,1);
  //   delay(500);
  //     phanhoidung("A","C");
  //    // delay(200);
  //   //guidata(ec1, h1, ec2, h2, "A", "D");
  //   chedo=0;
  //     }
      
  //   }
    // else if(result==3){
    //   if(kieutruyen==0){
    //   digitalWrite(De,1);
    // digitalWrite(Re,1);
    // delay(200);
    // phanhoisai("A","B");
    
    //   }
    // }
  //   else if(result==4){
  //     if(kieutruyen==0){
  //     digitalWrite(De,1);
  //   digitalWrite(Re,1);
  //    delay(200);
  //   phanhoisai("A","C");
  //  }
  //   }
  //   else;
    
                  //Serial.print(result);
//                   Serial.print(" ");
//               Serial.print(chedo);
//       Serial.print(" ");
// Serial.println(kieutruyen);

// digitalWrite(De,1);
//     digitalWrite(Re,1);
 //phanhoidung("A","B");
// digitalWrite(De,0);
//     digitalWrite(Re,0);
    // Serial.print(ec1);
    // Serial.print(" ");
    // Serial.print(h1);
    // Serial.print(" ");
    // Serial.print(digitalRead(De));
    // Serial.print(" ");
    // Serial.println(h2);
    
  
  if(chedo==0){
    // digitalWrite(De,1);
    // digitalWrite(Re,1);
    delay(100);
    digitalWrite(De,1);
    digitalWrite(Re,1);
    guidata(ec1,h1, ec2 , h2,"A","D");
    chedo=1;
  }

  // String pack = "";
  // while (Serial.available()) {
  //   char c = (char)Serial.read();
  //   pack +=c;
  //   Serial.print(c);
  //   //Serial.print("");
  //   delay(5);
  // }
  // pack.trim();
  // Serial.println(pack);
  }
  delay(100);
  if(npk==1){
  AB:
  t_time=millis();
  
  delay(200);
yeucaudoc("A","C");
delay(200);
opp=0;
ec1=0; h1=0;
goto AC;}
}

//@AB0812031456crc#




