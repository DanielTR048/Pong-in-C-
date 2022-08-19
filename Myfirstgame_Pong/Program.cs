using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Input;
using OpenTK.Graphics.OpenGL;
using System.Timers;
using System.Threading;

namespace Myfirstgame_Pong
{

    class Program : GameWindow
    {
        double xofball = 0; //percorre o eixo x
        int yofball = 0; //percorre o eixo y
        int sizeofball = 20; // tamanho da bola
        double velocityofballinX = 3; // velocidade da bola em x
        int velocityofballinY = 3; // velocidade da bola em y

        int start = 0;
        int clock = 0;

        double accelation = 1.2;

        int Yplayer1 = 0;
        int Yplayer2 = 0;

        int placarP1 = 0;
        int placarP2 = 0;

        int md3P1 = 0;
        int md3Round2P1 = 0;
        int md3Round3P1 = 0;
        int md3Round2P2 = 0;
        int md3Round3P2 = 0;
        int md3P2 = 0;




        int Xplayer1()
        {
            return -ClientSize.Width / 2 + SizeofWidth() / 2;
        }
        int Xplayer2()
        {
            return ClientSize.Width / 2 - SizeofWidth() / 2;
        }

        int SizeofWidth()
        {
            return sizeofball;
        }

        int SizeofHeight()
        {
            return 4 * sizeofball;
        }

        int PlacarPlayer1X()
        {
            return -ClientSize.Width / 5 + 20 / 2;
        }

        int PlacarPlayer2X()
        {
            return ClientSize.Width / 5 - 20 / 2;
        }

        int positionMd3P1X()
        {
            return -ClientSize.Width / 5 + 20 / 2;
        }

        int positionMd3P2X()
        {
            return ClientSize.Width / 5 - 20 / 2;
        }

        int PositionMd3Y()
        {
            return ClientSize.Height / 2;
        }

        int PlacarY()
        {
            return ClientSize.Height / 3;
        }

        void PlacarUpdateP1()
        {
            switch (placarP1)
            {
                case 0:
                    number0P1();
                    break;

                case 1:
                    number1P1();
                    break;

                case 2:
                    number2P1();
                    break;

                case 3:
                    number3P1();
                    break;

                case 4:
                    number4P1();
                    break;

                case 5:
                    number5P1();
                    break;

                case 6:
                    number6P1();
                    break;


                case 7:
                    number7P1();
                    break;


                case 8:
                    number8P1();
                    break;

                case 9:
                    number9P1();
                    break;


                default:
                    break;
            }
        }

        void PlacarUpdateP2()
        {
            switch (placarP2)
            {
                case 0:
                    number0P2();
                    break;

                case 1:
                    number1P2();
                    break;

                case 2:
                    number2P2();
                    break;

                case 3:
                    number3P2();
                    break;

                case 4:
                    number4P2();
                    break;

                case 5:
                    number5P2();
                    break;

                case 6:
                    number6P2();
                    break;


                case 7:
                    number7P2();
                    break;


                case 8:
                    number8P2();
                    break;

                case 9:
                    number9P2();
                    break;


                default:
                    break;
            }
        }



        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            clock = clock + 1;

                if (clock == 3600)
                {
                    clock = 0;
                    velocityofballinX *= accelation;
                }
            

            if (Keyboard.GetState().IsKeyDown(Key.Space))
            {
                start = 1;
            }

            if (Keyboard.GetState().IsKeyDown(Key.Enter))
            {
                start = 0;
            }

            if (start == 1)
            {
                xofball = xofball + velocityofballinX;
                yofball = yofball + velocityofballinY;
            }






            //detectando colisao com o jogador do lado direito
            if (xofball + sizeofball / 2 > Xplayer2() - SizeofWidth() / 2
                && yofball - sizeofball / 2 < Yplayer2 + SizeofHeight() / 2
                && yofball + sizeofball / 2 > Yplayer2 - SizeofHeight() / 2)
            {
                
                velocityofballinX = -velocityofballinX;

            }

            //detectando colisao com o jogador do lado esquerdo
            if (xofball - sizeofball / 2 < Xplayer1() + SizeofWidth() / 2
                && yofball - sizeofball / 2 < Yplayer1 + SizeofHeight() / 2
                && yofball + sizeofball / 2 > Yplayer1 - SizeofHeight() / 2)
            {
                velocityofballinX = -velocityofballinX;

            }

            //dectando colisao em cima
            if (yofball + sizeofball / 2 > ClientSize.Height / 2)
            {
                velocityofballinY = -velocityofballinY;
            }

            //detectando colisao em baixo
            if (yofball - sizeofball / 2 < -ClientSize.Height / 2)
            {
                velocityofballinY = -velocityofballinY;
            }

            //detecta colisão na esquerda
            if (xofball < -ClientSize.Width / 2)
            {
                xofball = 0;
                yofball = 0;
                velocityofballinX = -velocityofballinX;

                placarP2++;
                if (placarP2 > 9)
                {
                    placarP2 = 0;
                    md3P2++;
                    if (md3P2 == 2)
                    {
                        md3Round2P2++;
                    }
                    if (md3P2 == 3)
                    {
                        md3Round3P2++;
                    }
                }
            }

            //detecta colisão na direita
            if (xofball > ClientSize.Width / 2)
            {
                xofball = 0;
                yofball = 0;
                velocityofballinX = -velocityofballinX;

                placarP1++;
                if (placarP1 > 9)
                {
                    placarP1 = 0;
                    md3P1++;
                    if (md3P1 == 2)
                    {
                        md3Round2P1++;
                    } 
                    if (md3P1 == 3)
                    {
                        md3Round3P1++;
                    }
                }

            }

            if (Keyboard.GetState().IsKeyDown(Key.W))
            {
                Yplayer1 = Yplayer1 + 5;
            }


            if (Keyboard.GetState().IsKeyDown(Key.S))
            {
                Yplayer1 = Yplayer1 - 5 ;
            }

            if (Keyboard.GetState().IsKeyDown(Key.Up))
            {
                Yplayer2 = Yplayer2 + 5;
            }


            if (Keyboard.GetState().IsKeyDown(Key.Down))
            {
                Yplayer2 = Yplayer2 - 5;
            }

            if (Keyboard.GetState().IsKeyDown(Key.R))
            {
                velocityofballinX = 3;
                xofball = 0;
                yofball = 0;
                clock = 0;
                md3P1 = 0;
                md3Round2P1 = 0;
                md3Round3P1 = 0;
                md3P2 = 0;
                md3Round2P2 = 0;
                md3Round3P2 = 0;
                placarP1 = 0;
                placarP2 = 0;
            }
        }

        void MD3R1P1()
        {
            switch (md3P1)
            {
                case 0:
                md3R1P1();
                    break;
                case 1:
                md3R1P1ON();
                    break;
                case 2:
                md3R1P1ON();
                    break;
                case 3:
                md3R1P1ON();
                    break;
                default:
                    md3P1 = 0;
                    md3Round2P1 = 0;
                    md3Round3P1 = 0;
                    break;
            }
        }

        void MD3R2P1()
        {
            switch (md3Round2P1)
            {
                case 0:
                    md3R2P1();
                    break;
                case 1:
                    md3R2P1ON();
                    break;
                default:
                    md3P1 = 0;
                    md3Round2P1 = 0;
                    md3Round3P1 = 0;
                    break;
            }
        }

        void MD3R3P1()
        {
            switch (md3Round3P1)
            {
                case 0:
                    md3R3P1();
                    break;
                case 1:
                    md3R3P1ON();
                    break;
                default:
                    md3P1 = 0;
                    md3Round2P1 = 0;
                    md3Round3P1 = 0;
                    break;
            }
        }

        void MD3R1P2()
        {
            switch (md3P2)
            {
                case 0:
                    md3R1P2();
                    break;
                case 1:
                    md3R1P2ON();
                    break;
                case 2:
                    md3R1P2ON();
                    break;
                case 3:
                    md3R1P2ON();
                    break;
                default:
                    md3P2 = 0;
                    md3Round2P2 = 0;
                    md3Round3P2 = 0;
                    break;
            }
        }

        void MD3R2P2()
        {
            switch (md3Round2P2)
            {
                case 0:
                    md3R2P2();
                    break;
                case 1:
                    md3R2P2ON();
                    break;
                default:
                    md3P2 = 0;
                    md3Round2P2 = 0;
                    md3Round3P2 = 0;
                    break;
            }
        }

        void MD3R3P2()
        {
            switch (md3Round3P2)
            {
                case 0:
                    md3R3P2();
                    break;
                case 1:
                    md3R3P2ON();
                    break;
                default:
                    md3P2 = 0;
                    md3Round2P2 = 0;
                    md3Round3P2 = 0;
                    break;
            }
        }

        void md3Player1()
        {
            MD3R1P1();
            MD3R2P1();
            MD3R3P1();
        }

        void md3Player2()
        {
            MD3R1P2();
            MD3R2P2();
            MD3R3P2();
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {

            GL.Viewport(0, 0, ClientSize.Width, ClientSize.Height);
            Matrix4 projection = Matrix4.CreateOrthographic(ClientSize.Width, ClientSize.Height, 0.0f, 1.0f);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);

            GL.Clear(ClearBufferMask.ColorBufferBit);


            Draw(xofball, yofball, sizeofball, sizeofball, 1.0f, 1.0f, 1.0f); //Central Squartle
            Draw(Xplayer1(), Yplayer1, SizeofWidth(), SizeofHeight(), 1.0f, 0.0f, 0.0f); //Left rectangle red
            Draw(Xplayer2(), Yplayer2, SizeofWidth(), SizeofHeight(), 0.0f, 1.0f, 0.0f); //Right rectangle green
            Draw(0, 0, 10, ClientSize.Height, 1.0f, 1.0f, 0.0f); //Central line yellow
            PlacarUpdateP1();
            PlacarUpdateP2();
            md3Player1();
            md3Player2();

            SwapBuffers();

            
        }

        void Draw(double x, int y, int width, int height, float r, float g, float b)
        {
            GL.Color3(r, g, b);

            GL.Begin(PrimitiveType.Quads);

            GL.Vertex2(-0.5f * width + x, -0.5f * height + y);
            GL.Vertex2(0.5f * width + x, -0.5f * height + y);
            GL.Vertex2(0.5f * width + x, 0.5f * height + y);
            GL.Vertex2(-0.5f * width + x, 0.5f * height + y);

            GL.End();
        }

        //md3 off
        void md3R1P1()
        {
            Draw(positionMd3P1X() -10, PositionMd3Y() - 20, 20, 20, 1.0f, 1.0f, 1.0f);
        }
        void md3R2P1()
        {
            Draw(positionMd3P1X() + 40, PositionMd3Y() - 20, 20, 20, 1.0f, 1.0f, 1.0f);
        }
        void md3R3P1()
        {
            Draw(positionMd3P1X() + 90, PositionMd3Y() - 20, 20, 20, 1.0f, 1.0f, 1.0f);
        }
        void md3R1P2()
        {
            Draw(positionMd3P2X() + 10, PositionMd3Y() - 20, 20, 20, 1.0f, 1.0f, 1.0f);
        }
        void md3R2P2()
        {
            Draw(positionMd3P2X() - 40, PositionMd3Y() - 20, 20, 20, 1.0f, 1.0f, 1.0f);
        }
        void md3R3P2()
        {
            Draw(positionMd3P2X() - 90, PositionMd3Y() - 20, 20, 20, 1.0f, 1.0f, 1.0f);
        }

        //md3 on
        void md3R1P1ON()
        {
            Draw(positionMd3P1X() - 10, PositionMd3Y() - 20, 20, 20, 0.0f, 1.0f, 0.0f);
        }
        void md3R2P1ON()
        {
            Draw(positionMd3P1X() + 40, PositionMd3Y() - 20, 20, 20, 0.0f, 1.0f, 0.0f);
        }
        void md3R3P1ON()
        {
            Draw(positionMd3P1X() + 90, PositionMd3Y() - 20, 20, 20, 0.0f, 1.0f, 0.0f);
        }
        void md3R1P2ON()
        {
            Draw(positionMd3P2X() + 10, PositionMd3Y() - 20, 20, 20, 0.0f, 1.0f, 0.0f);
        }
        void md3R2P2ON()
        {
            Draw(positionMd3P2X() - 40, PositionMd3Y() - 20, 20, 20, 0.0f, 1.0f, 0.0f);
        }
        void md3R3P2ON()
        {
            Draw(positionMd3P2X() - 90, PositionMd3Y() - 20, 20, 20, 0.0f, 1.0f, 0.0f);
        }
        //numero 0 em pixel
        void number0P1()
        {
            Draw(PlacarPlayer1X() + 18, PlacarY(), 8, 8, 1.0f, 1.0f, 1.0f);
            Draw(PlacarPlayer1X() - 18, PlacarY(), 8, 8, 1.0f, 1.0f, 1.0f);

            Draw(PlacarPlayer1X() + 18, PlacarY() + 9, 8, 8, 1.0f, 1.0f, 1.0f);
            Draw(PlacarPlayer1X() + 18, PlacarY() + 18, 8, 8, 1.0f, 1.0f, 1.0f);
            Draw(PlacarPlayer1X() + 18, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 1.0f);
            Draw(PlacarPlayer1X() + 18, PlacarY() + 36, 8, 8, 1.0f, 1.0f, 1.0f);
            Draw(PlacarPlayer1X() + 18, PlacarY() - 9, 8, 8, 1.0f, 1.0f, 1.0f);
            Draw(PlacarPlayer1X() + 18, PlacarY() - 18, 8, 8, 1.0f, 1.0f, 1.0f);
            Draw(PlacarPlayer1X() + 18, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 1.0f);
            Draw(PlacarPlayer1X() + 18, PlacarY() - 36, 8, 8, 1.0f, 1.0f, 1.0f);

            Draw(PlacarPlayer1X() - 18, PlacarY() + 9, 8, 8, 1.0f, 1.0f, 1.0f);
            Draw(PlacarPlayer1X() - 18, PlacarY() + 18, 8, 8, 1.0f, 1.0f, 1.0f);
            Draw(PlacarPlayer1X() - 18, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 1.0f);
            Draw(PlacarPlayer1X() - 18, PlacarY() + 36, 8, 8, 1.0f, 1.0f, 1.0f);
            Draw(PlacarPlayer1X() - 18, PlacarY() - 9, 8, 8, 1.0f, 1.0f, 1.0f);
            Draw(PlacarPlayer1X() - 18, PlacarY() - 18, 8, 8, 1.0f, 1.0f, 1.0f);
            Draw(PlacarPlayer1X() - 18, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 1.0f);
            Draw(PlacarPlayer1X() - 18, PlacarY() - 36, 8, 8, 1.0f, 1.0f, 1.0f);

            Draw(PlacarPlayer1X(), PlacarY() - 36, 8, 8, 1.0f, 1.0f, 1.0f);
            Draw(PlacarPlayer1X() - 9, PlacarY() - 36, 8, 8, 1.0f, 1.0f, 1.0f);
            Draw(PlacarPlayer1X() + 9, PlacarY() - 36, 8, 8, 1.0f, 1.0f, 1.0f);

            Draw(PlacarPlayer1X(), PlacarY() + 36, 8, 8, 1.0f, 1.0f, 1.0f);
            Draw(PlacarPlayer1X() - 9, PlacarY() + 36, 8, 8, 1.0f, 1.0f, 1.0f);
            Draw(PlacarPlayer1X() + 9, PlacarY() + 36, 8, 8, 1.0f, 1.0f, 1.0f);
        }

        void number0P2()
        {
            Draw(PlacarPlayer2X() + 18, PlacarY(), 8, 8, 1.0f, 1.0f, 1.0f);
            Draw(PlacarPlayer2X() - 18, PlacarY(), 8, 8, 1.0f, 1.0f, 1.0f);

            Draw(PlacarPlayer2X() + 18, PlacarY() + 9, 8, 8, 1.0f, 1.0f, 1.0f);
            Draw(PlacarPlayer2X() + 18, PlacarY() + 18, 8, 8, 1.0f, 1.0f, 1.0f);
            Draw(PlacarPlayer2X() + 18, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 1.0f);
            Draw(PlacarPlayer2X() + 18, PlacarY() + 36, 8, 8, 1.0f, 1.0f, 1.0f);
            Draw(PlacarPlayer2X() + 18, PlacarY() - 9, 8, 8, 1.0f, 1.0f, 1.0f);
            Draw(PlacarPlayer2X() + 18, PlacarY() - 18, 8, 8, 1.0f, 1.0f, 1.0f);
            Draw(PlacarPlayer2X() + 18, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 1.0f);
            Draw(PlacarPlayer2X() + 18, PlacarY() - 36, 8, 8, 1.0f, 1.0f, 1.0f);
        
            Draw(PlacarPlayer2X() - 18, PlacarY() + 9, 8, 8, 1.0f, 1.0f, 1.0f);
            Draw(PlacarPlayer2X() - 18, PlacarY() + 18, 8, 8, 1.0f, 1.0f, 1.0f);
            Draw(PlacarPlayer2X() - 18, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 1.0f);
            Draw(PlacarPlayer2X() - 18, PlacarY() + 36, 8, 8, 1.0f, 1.0f, 1.0f);
            Draw(PlacarPlayer2X() - 18, PlacarY() - 9, 8, 8, 1.0f, 1.0f, 1.0f);
            Draw(PlacarPlayer2X() - 18, PlacarY() - 18, 8, 8, 1.0f, 1.0f, 1.0f);
            Draw(PlacarPlayer2X() - 18, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 1.0f);
            Draw(PlacarPlayer2X() - 18, PlacarY() - 36, 8, 8, 1.0f, 1.0f, 1.0f);

            Draw(PlacarPlayer2X(), PlacarY() - 36, 8, 8, 1.0f, 1.0f, 1.0f);
            Draw(PlacarPlayer2X() - 9, PlacarY() - 36, 8, 8, 1.0f, 1.0f, 1.0f);
            Draw(PlacarPlayer2X() + 9, PlacarY() - 36, 8, 8, 1.0f, 1.0f, 1.0f);

            Draw(PlacarPlayer2X(), PlacarY() + 36, 8, 8, 1.0f, 1.0f, 1.0f);
            Draw(PlacarPlayer2X() - 9, PlacarY() + 36, 8, 8, 1.0f, 1.0f, 1.0f);
            Draw(PlacarPlayer2X() + 9, PlacarY() + 36, 8, 8, 1.0f, 1.0f, 1.0f);
        }

        //numero 1 em pixel
        void number1P1()
        {

            Draw(PlacarPlayer1X(), PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X(), PlacarY() +9, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X(), PlacarY() +18, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X(), PlacarY() +27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X(), PlacarY() - 9, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X(), PlacarY() - 18, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X(), PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer1X() + 9, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 18, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 27, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer1X() - 9, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 18, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 27, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer1X() - 9, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 18, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 27, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
        }

        void number1P2()
        {
            Draw(PlacarPlayer2X(), PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X(), PlacarY() + 9, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X(), PlacarY() + 18, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X(), PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X(), PlacarY() - 9, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X(), PlacarY() - 18, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X(), PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer2X() + 9, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 18, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 27, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer2X() - 9, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 18, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 27, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer2X() - 9, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 18, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 27, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
        }
        // numero 2 em pixel
        void number2P1()
        {
            Draw(PlacarPlayer1X(), PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 9, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 18, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 27, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 9, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 18, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 27, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer1X() - 27, PlacarY() - 9, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 27, PlacarY() - 18, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 27, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer1X() - 18, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 9, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X(), PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 9, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 18, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 27, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);


            Draw(PlacarPlayer1X() + 27, PlacarY() + 9, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 27, PlacarY() + 18, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 27, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer1X() + 18, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 9, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X(), PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() -9, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() -18, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() -27, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);

        }
        void number2P2()
        {
            Draw(PlacarPlayer2X(), PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 9, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 18, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 27, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 9, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 18, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 27, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer2X() - 27, PlacarY() - 9, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 27, PlacarY() - 18, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 27, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer2X() - 18, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 9, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X(), PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 9, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 18, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 27, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);


            Draw(PlacarPlayer2X() + 27, PlacarY() + 9, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 27, PlacarY() + 18, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 27, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer2X() + 18, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 9, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X(), PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 9, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 18, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 27, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
        }

        // numero 3 em pixel
        void number3P1()
        {
            Draw(PlacarPlayer1X(), PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 9, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 18, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 27, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 9, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 18, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 27, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer1X() + 27, PlacarY() + 9, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 27, PlacarY() + 18, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 27, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer1X() + 27, PlacarY() - 9, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 27, PlacarY() - 18, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 27, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer1X() + 18, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 9, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X(), PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 9, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 18, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 27, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);


            Draw(PlacarPlayer1X() + 18, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 9, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X(), PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 9, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 18, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 27, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
        }
        void number3P2()
        {
            Draw(PlacarPlayer2X(), PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 9, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 18, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 27, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 9, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 18, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 27, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer2X() + 27, PlacarY() + 9, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 27, PlacarY() + 18, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 27, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer2X() + 27, PlacarY() - 9, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 27, PlacarY() - 18, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 27, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer2X() + 18, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 9, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X(), PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 9, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 18, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 27, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);


            Draw(PlacarPlayer2X() + 18, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 9, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X(), PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 9, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 18, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 27, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
        }

        // numero 4 em pixel
        void number4P1()
        {
            Draw(PlacarPlayer1X(), PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 9, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 18, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 27, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 9, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 18, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 27, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer1X() + 27, PlacarY() + 9, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 27, PlacarY() + 18, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 27, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 27, PlacarY() - 9, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 27, PlacarY() - 18, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 27, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer1X() - 27, PlacarY() + 9, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 27, PlacarY() + 18, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 27, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
        }
        void number4P2()
        {
            Draw(PlacarPlayer2X(), PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 9, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 18, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 27, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 9, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 18, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 27, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer2X() + 27, PlacarY() + 9, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 27, PlacarY() + 18, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 27, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 27, PlacarY() - 9, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 27, PlacarY() - 18, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 27, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer2X() - 27, PlacarY() + 9, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 27, PlacarY() + 18, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 27, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
        }

        // numero 5 em pixel
        void number5P1()
        {
            Draw(PlacarPlayer1X(), PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 9, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 18, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 27, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 9, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 18, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 27, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer1X() - 27, PlacarY() + 9, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 27, PlacarY() + 18, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 27, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer1X() - 18, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 9, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X(), PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 9, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 18, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 27, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer1X() + 27, PlacarY() - 9, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 27, PlacarY() - 18, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 27, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer1X() + 18, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 9, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X(), PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 9, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 18, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 27, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
        }
        void number5P2()
        {
            Draw(PlacarPlayer2X(), PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 9, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 18, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 27, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 9, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 18, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 27, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer2X() - 27, PlacarY() + 9, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 27, PlacarY() + 18, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 27, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer2X() - 18, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 9, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X(), PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 9, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 18, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 27, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer2X() + 27, PlacarY() - 9, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 27, PlacarY() - 18, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 27, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer2X() + 18, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 9, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X(), PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 9, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 18, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 27, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
        }

        // numero 6 em pixel
        void number6P1()
        {
            Draw(PlacarPlayer1X(), PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 9, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 18, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 27, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 9, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 18, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 27, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer1X() + 27, PlacarY() - 9, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 27, PlacarY() - 18, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 27, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer1X() + 18, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 9, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X(), PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 9, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 18, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer1X() - 27, PlacarY() + 9, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 27, PlacarY() + 18, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 27, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 27, PlacarY() - 9, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 27, PlacarY() - 18, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 27, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer1X() - 18, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 9, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X(), PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 9, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 18, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 27, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
        }
        void number6P2()
        {
            Draw(PlacarPlayer2X(), PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 9, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 18, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 27, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 9, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 18, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 27, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer2X() + 27, PlacarY() - 9, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 27, PlacarY() - 18, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 27, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer2X() + 18, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 9, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X(), PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 9, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 18, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer2X() - 27, PlacarY() + 9, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 27, PlacarY() + 18, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 27, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 27, PlacarY() - 9, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 27, PlacarY() - 18, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 27, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer2X() - 18, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 9, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X(), PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 9, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 18, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 27, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
        }

        // numero 7 em pixel
        void number7P1()
        {
            Draw(PlacarPlayer1X() + 27, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 27, PlacarY() + 9, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 27, PlacarY() + 18, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 27, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer1X() + 27, PlacarY() - 9, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 27, PlacarY() - 18, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 27, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer1X() + 18, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 9, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X(), PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 9, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 18, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 27, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
        }
        void number7P2()
        {
            Draw(PlacarPlayer2X() + 27, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 27, PlacarY() + 9, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 27, PlacarY() + 18, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 27, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer2X() + 27, PlacarY() - 9, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 27, PlacarY() - 18, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 27, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer2X() + 18, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 9, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X(), PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 9, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 18, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 27, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
        }

        // numero 8 em pixel
        void number8P1()
        {
            Draw(PlacarPlayer1X(), PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 9, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 18, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 27, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 9, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 18, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 27, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer1X() - 27, PlacarY() + 9, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 27, PlacarY() + 18, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 27, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 27, PlacarY() - 9, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 27, PlacarY() - 18, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 27, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer1X() + 9, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 18, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 9, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 18, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X(), PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer1X() + 27, PlacarY() + 9, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 27, PlacarY() + 18, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 27, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 27, PlacarY() - 9, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 27, PlacarY() - 18, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 27, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer1X() + 9, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 18, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 9, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 18, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X(), PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
        }
        void number8P2()
        {
            Draw(PlacarPlayer2X(), PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 9, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 18, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 27, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 9, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 18, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 27, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer2X() - 27, PlacarY() + 9, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 27, PlacarY() + 18, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 27, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 27, PlacarY() - 9, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 27, PlacarY() - 18, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 27, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer2X() + 9, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 9, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 18, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 18, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X(), PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer2X() + 27, PlacarY() + 9, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 27, PlacarY() + 18, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 27, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 27, PlacarY() - 9, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 27, PlacarY() - 18, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 27, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer2X() + 9, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 9, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 18, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 18, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X(), PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
        }

        // numero 9 em pixel
        void number9P1()
        {
            Draw(PlacarPlayer1X(), PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 9, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 18, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 27, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 9, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 18, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 27, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer1X() + 27, PlacarY() - 9, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 27, PlacarY() - 18, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 27, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 27, PlacarY() + 9, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 27, PlacarY() + 18, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 27, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer1X() + 18, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 9, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X(), PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 9, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 18, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer1X() - 27, PlacarY() + 9, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 27, PlacarY() + 18, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 27, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer1X() - 18, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() - 9, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X(), PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 9, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 18, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer1X() + 27, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
        }
        void number9P2()
        {
            Draw(PlacarPlayer2X(), PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 9, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 18, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 27, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 9, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 18, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 27, PlacarY(), 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer2X() + 27, PlacarY() - 9, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 27, PlacarY() - 18, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 27, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 27, PlacarY() + 9, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 27, PlacarY() + 18, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 27, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer2X() + 18, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 9, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X(), PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 9, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 18, PlacarY() - 27, 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer2X() - 27, PlacarY() + 9, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 27, PlacarY() + 18, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 27, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);

            Draw(PlacarPlayer2X() - 18, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() - 9, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X(), PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 9, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 18, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
            Draw(PlacarPlayer2X() + 27, PlacarY() + 27, 8, 8, 1.0f, 1.0f, 0.0f);
        }
        static void Main()
        {
            Console.WriteLine("Para começar aperte Espaço");
            Console.WriteLine("Para pausar aperte Enter");
            Console.WriteLine("Para resetar aperte R");
            new Program().Run();
            
        }
    }
}
