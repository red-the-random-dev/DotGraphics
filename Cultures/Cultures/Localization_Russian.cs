/*
 * Russian localization.
 */
using System;
using System.Globalization;
using System.Collections.Generic;

namespace DotGraphics.Cultures
{
	public static partial class Localization
	{
		static Dictionary<String, String> Russian = new Dictionary<string, string>();
		
		static void InitializeRussian()
		{
			// Window titles
			Russian.Add("wintitle", "DotGraphics Braille Renderer");
			Russian.Add("alerttitle", "Braille Renderer - Сообщение");
			// Success
			Russian.Add("ok_render", "Рендер текста завершён!");
			Russian.Add("ok_compiled", "Сборка холста завершена!");
			// Errors
			Russian.Add("error_pngnotfound", "Не удалось найти изображение по данному запросу.");
			Russian.Add("error_objectnotfound", "Не удалось найти объет по этому расположению: ");
			Russian.Add("error_renderdumpfail", "Нам не удалось записать объект в файл.");
			Russian.Add("error_objectloadfail", "Ёк-макарёк! С файлом, похоже, что-то не так!");
			Russian.Add("error_imageaspectratio", "Изображение не соответствует установленным параметрам: ширина не делится на 2 & высота не делится на 4.");
			Russian.Add("error_imagetoolarge", "Размер изображения слишком велик: ширина и высота должны быть меньше 65536 точек.");
			Russian.Add("error_renderfail", "Произошёл сбой во время разгрузки изображения в файл.");
			// Section titles
			Russian.Add("ui_complabel", "Собрать холст Брайля из PNG-изображения:");
			Russian.Add("ui_renderlabel", "Перенести содержимое холста в текст:");
			// Compile section
			Russian.Add("ui_pnglabel", "Расположение PNG-файла...");
			Russian.Add("ui_objlabel", "Путь сохранения объекта...");
			Russian.Add("ui_compilebutton", "Собрать");
			// Render section
			Russian.Add("ui_targetlabel", "Расположение согбранного холста...");
			Russian.Add("ui_txtlabel", "Путь сохранения текстового файла...");
			Russian.Add("ui_renderbutton", "Рендер");
			// Save, Load, and Show result
			Russian.Add("ui_loadbutton", "Открыть...");
			Russian.Add("ui_savebutton", "Сохранить...");
			Russian.Add("ui_showresult", "Показать результат после рендеринга изображения");
			// File type filters
			Russian.Add("filter_txt", "Текстовый документ (*.txt)|*.txt");
			Russian.Add("filter_png", "PNG-изображение (*.png)|*.png");
			Russian.Add("filter_o", "Сериализованный объект (*.o)|*.o");
			
			LanguageGetters.Add("ru-RU", GetRussian);
			Languages.Add("ru-RU");
		}
		
		static String GetRussian(String Key)
		{
			if (!Ready)
			{
				Initialize();
				return GetRussian(Key);
			}
			
			return Russian[Key];
		}
	}
}
