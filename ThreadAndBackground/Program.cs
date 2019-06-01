using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Media;
/*
* Создать приложение, которое позволяет проигрывать в фоне музыку (с использованием потока-демона), а также вести текстовые записи.
При закрытии приложения текстовые записи должны быть сохранены в отдельном потоке в файл (не используйте асинхронность для наглядности примера).
*/
namespace ThreadAndBackground
{
	class Program
	{
		static void Main(string[] args)
		{
			Thread threadMusic = new Thread(Startmusic);
			threadMusic.IsBackground = true;
			threadMusic.Start();
			Console.WriteLine("Введите текст для сохранения в файл");
			
			string text = Console.ReadLine();
			string path = "text.txt";
			using (StreamWriter writer=new StreamWriter(path))
			{
				writer.WriteLine(text);
			};
		}
		private static void Startmusic()
		{
			SoundPlayer player = new SoundPlayer();
			player.SoundLocation = "artur_pirozhkov_-_ja_ne_andrej_(zf.fm).wav";
			player.Play();
		}
	}
}
