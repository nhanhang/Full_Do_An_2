//khung truyen @+diachigui+maham+bytedata+crc+diachinhan#
//dia chi: A-master B-slave1 C-slave2 D-pc
//ma ham: 0-send 1-receive_success 2-receive_failure
#include <DFRobot_ESP_EC.h>
#include <stdio.h>
#include <stdlib.h>
#include "EEPROM.h"
#include "DHT.h"
#include <HardwareSerial.h>
#include <string.h>

//HardwareSerial SerialPort(2);  // use UART2

#define tem_pin 27
#define ec_pin 26
#define De 18
#define Re 19
String start, address_receive, address_sent, data, function, crc, length_data, Ec_str, Tem_str, pack, End;
char warring[12] = "@DE5017682#";
DFRobot_ESP_EC ec;

unsigned long per_time;
float voltage, ecValue, humiValue, temperature = 25;
//float ecValuef=12.88;
//float humiValuef=50.45;
int result = 0;  //1-success 2-failure
int chedo = 1;   //0-allow 1-unallow
int kieutruyen = 0;
int dem=1;
char* checkwr;
float DHTPIN = tem_pin;
const int DHTTYPE = DHT22;
DHT dht(DHTPIN, DHTTYPE);

int chuyen1(String a) {
  int l1 = a.length();
  int num = 0;
  for (int i = l1 - 1; i >= 0; --i) {
    num += (int)(a[i] - '0') * pow(10, l1 - i - 1);
  }
  return num + 48;
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
  crc = crc ^ b;
  int tt;
  for (int i = 0; i < 8; i++)
    if (crc & 0x0001) {
      crc = crc >> 1;
      crc = crc ^ 0xA001;
    } else {
      crc = crc >> 1;
    }
  return crc;
}


int value_crc(String address_sent2, String address_receive2, String funcion2, String length_data2, String data2) {
  int length = chuyen(length_data2);
  String k;
  int crc = 0xFFFF;
  int cl;
  crc = xorbyte(address_sent2, crc);
  crc = xorbyte(address_receive2, crc);
  crc = xorbyte(funcion2, crc);
  crc = xorbyte(length_data2, crc);
  for (int i = 0; i < length; i++) {
    k = data2.substring(i, i + 1);
    crc = xorbyte(k, crc);
  }
  return crc;
}
int value_crc1(String address_sent2, String address_receive2, String funcion2, String length_data2) {
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
void boctach(String dl, int length) {
  int value_length;
  int length_rs485 = dl.length();
  start = dl.substring(0, 1);
  address_sent = dl.substring(1, 2);
  address_receive = dl.substring(2, 3);
  function = dl.substring(3, 4);
  length_data = dl.substring(4, 5);
  value_length = chuyen(length_data);
  if (value_length == 0) {
    crc = dl.substring(5, length_rs485 - 1);
  } else {
    data = dl.substring(5, 5 + value_length);
    crc = dl.substring(5 + value_length, length_rs485 - 1);
  }
  End = dl.substring(length_rs485 - 1, length_rs485);
}

void docdata() {


  String pack = "";

  while (Serial2.available()) {
    char c = (char)Serial2.read();
    if(c=='@'){
      dem++;
    }
    pack += c;
    delay(5);
  }
  //Serial.println(pack);
  pack.trim();
  delay(100);

  if (pack != "") {
    int length = pack.length();
    char hihi[length+1];
    pack.toCharArray(hihi,length+1);
    checkwr = strstr(hihi,warring);
  if(checkwr!=NULL){
    pack = "@DE5017682#";
    dem=0;
  }
    if(dem==2){
    pack = pack.substring(length-11,length);
    dem=0;
  }
  else dem=0;
    int real_crc;
    int value_length;
    boctach(pack, length);
    if (start == "@" && End == "#") {
      value_length = chuyen(length_data);
      if (value_length == 0) {
        real_crc = value_crc1(address_sent, address_receive, function, length_data);
      } else {
        real_crc = value_crc(address_sent, address_receive, function, length_data, data);
      }
      int crc_pack = chuyen(crc);
      //Serial.println(crc);
      if (real_crc == crc_pack) {
        //Serial.println("hehe");
      //   if (function == "1" && address_sent == "D") {
      //     if(address_receive=="A"){
      //     if(kieutruyen==0){
      //     dem++;
      //     //Serial.println(dem);
      //     if(dem%2==1){
      //   chedo=0;} // dao nguoc khi sang slave 2
      // }
      //   }}
      if (function == "1" && address_sent == "A"){
        if(address_receive=="B"){
          chedo=0;
      }
      }
        else if(function == "3" && address_receive == "C"){
      if(address_sent == "D" && kieutruyen==1){
        //Serial.println("hehe");
        chedo=0;
      }
      else if (address_sent == "A" && kieutruyen == 0){
        chedo=0;
      }
      else;
    }
         else if (function == "2") {
          if (address_sent == "A") {
            if (address_receive == "C") {
              
              chedo = 0;
            } else chedo = 1;
          }
        } else if (address_sent == "D" && address_receive == "E") {
          if (function == "4") {
            dem=0;
            chedo = 1 ;
            kieutruyen = 0;
          } else {
            chedo = 1;
            kieutruyen = 1;
          }
        } 
        else;
      }
    }
  }
  pack = "";
  delay(100);
}

void guidata(float value_ec, float value_humi, String address_gui, String address_nhan) {
  int value_ec1, value_humi1;
  value_ec1 = value_ec * 100;
  value_humi1 = value_humi * 100;
  String str_ec = "";
  String str_humi = "";
  String str_crc = "";
  String str_length = "";
  str_ec.concat(value_ec1);
  str_humi.concat(value_humi1);
  String data1;
  String h = "0";
  data1 = str_humi + str_ec;
  //Serial.print(data1);
  int length_data1;
  length_data1 = data1.length();
  str_length.concat(length_data1);
  int crc10 = value_crc(address_gui, address_nhan, "0", str_length, data1);
  str_crc.concat(crc10);
  String pack1;
  pack1 = "@" + address_gui + address_nhan + "0" + str_length + data1 + str_crc + "#";
  Serial2.print(pack1);
  Serial.println(pack1);
}

void setup() {
  // put your setup code here, to run once:
  Serial.begin(115200);
  Serial2.begin(115200);
  pinMode(ec_pin, INPUT);
  pinMode(tem_pin, INPUT);
  pinMode(De, OUTPUT);
  pinMode(Re, OUTPUT);
  EEPROM.begin(32);  //needed EEPROM.begin to store calibration k in eeprom
  ec.begin();        //by default lib store calibration k since 10 change it by set ec.begin(30); to start from 30
  //per_time = millis();
  dht.begin();
  digitalWrite(De, 1);
  digitalWrite(Re, 1);
  float a[10], b[10], humi, temp;
  humi = 0;
  ecValue = 0;
  delay(10);
}
//const uint16_t buf="101556";
//int len=buf.length();


void loop() {
  //master
  //float ec1,ec2,T1, T2;
  float a[10], b[10], humi, temp;

  static unsigned long timepoint = millis();
  if (millis() - timepoint > 10U)  //time interval: 1s
  {
    timepoint = millis();
    delay(100);
    digitalWrite(De, 0);
    digitalWrite(Re, 0);
    docdata();
    
    // Serial.print("voltage:");
    //  Serial.print(voltage);

    // //temperature = readTemperature();  // read your temperature sensor to execute temperature compensation
    // Serial.print(" temperature:");
    // Serial.print(temperature);
    // Serial.print("^C");
      for (int i = 0; i < 10; i++) {
        voltage = (analogRead(26) * 3300 / 4096);
        a[i] = ec.readEC(voltage, temperature);
        delay(30);  // convert voltage to EC with temperature compensation
        //b[i] = dht.readHumidity();
      }
      for (int i = 0; i < 9; i++) {
        // for (int j = i + 1; j < 10; j++) {
        if (a[i] > a[i + 1]) {
          temp = a[i];
          a[i] = a[i + 1];
          a[i + 1] = temp;
        }
        if (b[i] > b[i + 1]) {
          temp = b[i];
          b[i] = b[i + 1];
          b[i + 1] = temp;
        }
        //}
      }
      for (int i = 5; i < 10; i++) {
        //humi += b[i];
        ecValue += a[i];
      }
      humi=dht.readHumidity();;
      ecValue = ecValue / 6;
        Serial.print(humi);
        Serial.print(" ");
         Serial.print(ecValue);
         Serial.println(" ");
         Serial.println(dht.readHumidity());
      delay(100);
//       Serial.print(chedo);
//       Serial.print(" ");
// Serial.println(kieutruyen);
    
    if (chedo == 0) {
      digitalWrite(De, 1);
      digitalWrite(Re, 1);
          if(kieutruyen==0){
  guidata(ecValue,humi,"C","A");}
  else guidata(ecValue,humi,"C","D");
      delay(100);
      chedo = 1;
    }
  }
  delay(100);
  ec.calibration(voltage, temperature);  // calibration process by Serail CMD
}
//@AB0812031456crc#
