using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Assignment1
{
    class DefaultPieceFormation
    {
        Piece[,] pieceArray;
        int size;
        static List<string> piece_texture_name;

        // ctor
        public DefaultPieceFormation()
        {
            piece_texture_name = new List<string>();
            // the pieces texture will appear in the default formation
            piece_texture_name.Add("pieces/piece_wood");
            piece_texture_name.Add("pieces/piece_redball");
            piece_texture_name.Add("pieces/piece_greenball");
            piece_texture_name.Add("pieces/piece_purpleball");
            piece_texture_name.Add("pieces/piece_skyblueball");
            piece_texture_name.Add("pieces/piece_smile");
            piece_texture_name.Add("pieces/piece_basketball");

            // default size is 8x8
            size = 8;
            pieceArray = new Piece[size, size];
            for (int i = 0; i < pieceArray.GetLength(0); i++)
            {
                for (int j = 0; j < pieceArray.GetLength(1); j++)
                {
                    pieceArray[i, j] = new Piece();
                }
            } 
        }

        public void Initialize(ContentManager content)
        {
            // randomize the pieces
            PieceRandomize();

            // starting point
            Vector2 pos = new Vector2(200.0f, 200.0f);
            // loop through the pieces
            for (int i = 0; i < pieceArray.GetLength(0); i++)
            {
                for (int j = 0; j < pieceArray.GetLength(1); j++)
                {
                    pieceArray[i, j].Initialize(content, ref pos);
                    pos.X += 50.0f;
                    if (j == size/2-1)
                        pos.X += 100.0f;
                }
                pos.Y += 50.0f;
                if (i == size/2-1)
                    pos.Y += 100.0f;
                pos.X = 200.0f;
            }            
        }

        public void Update(ContentManager content)
        {
            PieceRandomize();
            for (int i = 0; i < pieceArray.GetLength(0); i++)
            {
                for (int j = 0; j < pieceArray.GetLength(1); j++)
                {
                    pieceArray[i, j].Update(content);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // loop through to draw the pieces
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    pieceArray[i, j].Draw(spriteBatch);
                }
            }
        }

        private void PieceRandomize()
        {
            Random random_int = new Random();
            for (int i = 0; i < pieceArray.GetLength(0); i++)
            {
                for (int j = 0; j < pieceArray.GetLength(1); j++)
                {
                    int ran = random_int.Next(0, piece_texture_name.Count);
                    pieceArray[i,j].SetTextureName(piece_texture_name[ran]);
                }
            }
        }
    }
    
    class Piece
    {
        Texture2D piece_texture;
        string piece_texture_name;
        Vector2 piece_pos;
        Vector2 scale;

        public Piece()
        {
            piece_pos = new Vector2(0.0f, 0.0f);
            scale = new Vector2(1.0f, 1.0f);
            piece_texture_name = "pieces/piece_default";
        }

        public void SetTextureName(string texture_name)
        {
            piece_texture_name = texture_name;
        }

        public void Initialize(ContentManager content, ref Vector2 position)
        {
            piece_texture = content.Load<Texture2D>(piece_texture_name);
            piece_pos = position;
        }

        public void Update(ContentManager content)
        {
            piece_texture = content.Load<Texture2D>(piece_texture_name);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(piece_texture, piece_pos, Color.White);
            spriteBatch.Draw(piece_texture, piece_pos, null, Color.White, 0.0f, Vector2.Zero, scale, SpriteEffects.None, 0.0f);
        }
    }
}
