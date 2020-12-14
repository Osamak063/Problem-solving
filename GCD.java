/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gcd;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileWriter;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Scanner;

/**
 *
 * @author Osama Khalid
 */
public class GCD {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) throws IOException {
     Scanner in = new Scanner(System.in);
        int a,b,c;
        String input,x="",y="";
        System.out.print("Sample Input: ");

     BufferedReader inp = new BufferedReader (new InputStreamReader(System.in));
       input=inp.readLine();
       FileWriter fstream = new FileWriter("q4.txt");
        BufferedWriter out = new BufferedWriter(fstream);
        out.write(input);
        out.close();
        for (int i = 0; i <input.length(); i++) {
            if(input.charAt(i)==',')
            { 
                for (int j = 0; j < i; j++) {
                    x+=String.valueOf(input.charAt(j));
                }
               for (int k = i+2; k < input.length(); k++) {
                    y+=String.valueOf(input.charAt(k));
                 
                }
            }
            
        }
       
        a=Integer.parseInt(x);
        b=Integer.parseInt(y);
        
       while(a!=0 && b!=0) // until either one of them is 0
  {
      c = b;
     b = a%b;
     a = c;
  }
        System.out.println("Sample Output: "+(a+b));
    }
    
}
