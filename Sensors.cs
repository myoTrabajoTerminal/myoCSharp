using System;
using System.Collections.Generic;

namespace Sensores {
    public class Sensors {
        private string clase;
        private List<int> sensor1;
        private List<int> sensor2;
        private List<int> sensor3;
        private List<int> sensor4;
        private List<int> sensor5;
        private List<int> sensor6;
        private List<int> sensor7;
        private List<int> sensor8;
        public Sensors () {
            sensor1 = new List<int> ();
            sensor2 = new List<int> ();
            sensor3 = new List<int> ();
            sensor4 = new List<int> ();
            sensor5 = new List<int> ();
            sensor6 = new List<int> ();
            sensor7 = new List<int> ();
            sensor8 = new List<int> ();
        }
        public void setVector (int number, List<int> data) {
            switch (number) {
                case 1:
                    sensor1 = data;
                    break;
                case 2:
                    sensor2 = data;
                    break;
                case 3:
                    sensor3 = data;
                    break;
                case 4:
                    sensor4 = data;
                    break;
                case 5:
                    sensor5 = data;
                    break;
                case 6:
                    sensor6 = data;
                    break;
                case 7:
                    sensor7 = data;
                    break;
                case 8:
                    sensor8 = data;
                    break;
                default:
                    Console.WriteLine ("El valor introducido es incorrecto");
                    break;
            } //switch 
        } //setVector
        public void append (int sensor, int dato) {
            switch (sensor) {
                case 1:
                    sensor1.Add (dato);
                    break;
                case 2:
                    sensor2.Add (dato);
                    break;
                case 3:
                    sensor3.Add (dato);
                    break;
                case 4:
                    sensor4.Add (dato);
                    break;
                case 5:
                    sensor5.Add (dato);
                    break;
                case 6:
                    sensor6.Add (dato);
                    break;
                case 7:
                    sensor7.Add (dato);
                    break;
                case 8:
                    sensor8.Add (dato);
                    break;
            } //switch
        } //append
        public void clearVector () {
            sensor1.Clear ();
            sensor2.Clear ();
            sensor3.Clear ();
            sensor4.Clear ();
            sensor5.Clear ();
            sensor6.Clear ();
            sensor7.Clear ();
            sensor8.Clear ();
        }
        public void printVector (int sensor) {
            switch (sensor) {
                case 1:
                    foreach (var value in sensor1) {
                        Console.Write (value + ",");
                    }
                    break;
                case 2:
                    foreach (var value in sensor2) {
                        Console.Write (value + ",");
                    }
                    break;
                case 3:
                    foreach (var value in sensor3) {
                        Console.Write (value + ",");
                    }
                    break;
                case 4:
                    foreach (var value in sensor4) {
                        Console.Write (value + ",");
                    }
                    break;
                case 5:
                    foreach (var value in sensor5) {
                        Console.Write (value + ",");
                    }
                    break;
                case 6:
                    foreach (var value in sensor6) {
                        Console.Write (value + ",");
                    }
                    break;
                case 7:
                    foreach (var value in sensor7) {
                        Console.Write (value + ",");
                    }
                    break;
                case 8:
                    foreach (var value in sensor8) {
                        Console.Write (value + ",");
                    }
                    break;
            } //switch
        } //printVector
        public List<int> getVector (int sensor) {
            switch (sensor) {
                case 1:
                    return sensor1;
                case 2:
                    return sensor2;
                case 3:
                    return sensor3;
                case 4:
                    return sensor4;
                case 5:
                    return sensor5;
                case 6:
                    return sensor6;
                case 7:
                    return sensor7;
                case 8:
                    return sensor8;
                default:
                    return null;
            } //switch
        }
        public void setClass (string cad) {
            clase = cad;
        }
        public string getClass () {
            return clase;
        }
    } //class
}