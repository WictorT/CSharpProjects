using System;
using System.IO;
namespace ConsoleApplication3
{
    class Program
    {
        public const int num = 20;
        public static int i = 0, j = 0, n, n1, m, x1=0, v=0, w=0;
        public static String[] words = File.ReadAllLines(@"words.txt");
        public static String[] input = File.ReadAllLines(@"tablou.in");
        public static byte[,] matrix = new byte[num, num];
        public static char[,] matrixc = new char[num, num];
        public static String[] rows = new String[num];
        public static int[] rowsinty = new int[num];
        public static int[] rowsintx = new int[num];
        public static int[,] rowsint = new int[num,num];
        public static int[] rowsbegy = new int[num];
        public static int[] rowsbegx = new int[num];
        public static int[] rowsdir = new int[num];
        public static int[] rowslen = new int[num];


        public static void Right(int y, int x)
        {
            if (matrix[y, x + 1] >= 2) { rowsinty[v] = y; rowsintx[v] = x + 1; v++; n1++; Right(y, x + 1); }
            if (matrix[y, x + 1] == 1) { matrix[y, x + 1] = (byte)(x1+2); n1++; Right(y, x + 1); }
        }

        public static void Down(int y, int x)
        {
            if (matrix[y + 1, x] >= 2) { rowsinty[v] = y + 1; rowsintx[v] = x; v++; n1++; Down(y + 1, x); }
            if (matrix[y + 1, x] == 1) { matrix[y + 1, x] = (byte)(x1+2); n1++; Down(y + 1, x); }
        }

        public static void Recursion(int n2, int l, char[,] mat)
        {
            int i;
            string[] rows = new string[num];
            bool b = true ;
                if (n2>-1) {
                    
            for (; l < words.Length; l++){ b=false ; 
                    if ((rowslen[n2] == words[l].Length - 1) && (rowsdir[n2] == 1)) { b=true ;
                        for (i = 0; i < words[l].Length; i++){
                             if ((mat[rowsbegy[n2], rowsbegx[n2] + i] == '1') || (mat[rowsbegy[n2], rowsbegx[n2] + i] == words[l][i]))
                                { } else { b = false; } } 
                        if (b) {
                        for (i = 0; i < words[l].Length; i++){
                    mat[rowsbegy[n2], rowsbegx[n2] + i] = words[l][i];} if (n2 == x1 - 1) w = l+1 ; Recursion(n2-1, l + 1, mat) ;}}

                    if ((rowslen[n2] == words[l].Length - 1) && (rowsdir[n2] == 0)) { b=true ;
                        for (i = 0; i < words[l].Length; i++){
                             if ((mat[rowsbegy[n2] + i, rowsbegx[n2]] == '1') || (mat[rowsbegy[n2] + i, rowsbegx[n2]] == words[l][i]))
                                { } else { b = false; } } 
                        if (b) {
                        for (i = 0; i < words[l].Length; i++){
                    mat[rowsbegy[n2] + i, rowsbegx[n2]] = words[l][i];} if (n2 == x1 - 1) w = l+1 ; Recursion(n2-1, l + 1, mat) ; }}}}
                    else {
                        Console.Clear();
                        for (int i1 = 1; i1 < n-1; i1++)
                        {
                            for (int j1 = 1; j1 < m-1; j1++)
                            {
                                rows[i1] += mat[i1, j1];
                                if (mat[i1, j1] == '0') { { Console.Write(" "); } } else { Console.Write(mat[i1, j1]); }
                            } Console.WriteLine();
                            File.WriteAllLines("tablou.out", rows, System.Text.Encoding.UTF8);
                          }
                        } 
                }

           
        static void Main(string[] args)
        {
            char[,] matrixcc = new char[num, num];

            for (i=0 ; i<input.Length ; i++)
            {
                for (j=0 ; j<input[i].Length ; j++) {
                    matrix[i,j] = (byte)(input[i][j]-48) ;
                    matrixc[i,j] = input[i][j];
                    matrixcc[i,j] = input[i][j];
                }
            } n = i; m = j;

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    if (matrix[i, j]>=1)
                    {
                        if ((matrix[i, j + 1] == 1) && (matrix[i, j]>=1) || (matrix[i, j + 1] >= 1) && (matrix[i, j]==1)) { 
                            rowsdir[x1]=1 ; matrix[i, j] = (byte)(x1 + 2); n1 = 0; rowsbegy[x1] = i; rowsbegx[x1] = j; 
                            Right(i, j); rowslen[x1] = n1; x1++; }

                        if ((matrix[i + 1, j] == 1) && (matrix[i, j] >= 1) || (matrix[i +1 , j] >= 1) && (matrix[i, j] == 1))
                        {
                            rowsdir[x1] = 0; matrix[i, j] = (byte)(x1 + 2); n1 = 0; rowsbegy[x1] = i; rowsbegx[x1] = j; 
                            Down(i, j); rowslen[x1] = n1; x1++; }                         
                    }
                }  
            }
            while (w < words.Length)
            {
                                
                for (i = 0; i < input.Length; i++)
                {
                    for (j = 0; j < input[i].Length; j++) { matrixcc[i, j] = matrixc[i, j]; }
                }
             
                Recursion(x1 - 1, w, matrixcc);
                Console.ReadKey();
            }
        }
    }
}
