global using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using PdfSharp.Pdf;
using PdfSharp.Pdf.AcroForms;
using Syncfusion.Drawing;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeyondCreator.Data;
using BeyondCreator.Models;
using Microsoft.CodeAnalysis;
using System.Reflection.Metadata;
using System.Xml.Linq;
using Document = iTextSharp.text.Document;
using iTextSharp.text;
using iTextSharp.tool.xml.html;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BeyondCreator.Controllers
{
    public class CharactersController : Controller
    {
        private readonly BeyondCreatorContext _context;

        public CharactersController(BeyondCreatorContext context)
        {
            _context = context;
        }

        // GET: Characters
        public async Task<IActionResult> Index()
        {
            return View(await _context.Character.ToListAsync());
        }

        // GET: Characters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Character == null)
            {
                return NotFound();
            }

            var character = await _context.Character
                .FirstOrDefaultAsync(m => m.Id == id);
            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }

        // GET: Characters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Characters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Race,PlayersName,Strenght,Dexterity,Perseption,Charisma,Intellegence,Vitality,Will,Lvl,Experience,Weapon1,Weapon2,Weapon3,Advantage1,Advantage2,Advantage3,Disadvantage1,Disadvantage2,Disadvantage3,Profession1,Profession2,Profession3,HeadArmour,BodyArmour,ArmsArmour,LegsArmour,BonusArmour,Resistance,Date")] Character character)
        {
            if (ModelState.IsValid)
            {
                _context.Add(character);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(character);
        }

        // GET: Characters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Character == null)
            {
                return NotFound();
            }

            var character = await _context.Character.FindAsync(id);
            if (character == null)
            {
                return NotFound();
            }
            return View(character);
        }

        // POST: Characters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Race,PlayersName,Strenght,Dexterity,Perseption,Charisma,Intellegence,Vitality,Will,Lvl,Experience,Weapon1,Weapon2,Weapon3,Advantage1,Advantage2,Advantage3,Disadvantage1,Disadvantage2,Disadvantage3,Profession1,Profession2,Profession3,HeadArmour,BodyArmour,ArmsArmour,LegsArmour,BonusArmour,Resistance,Date")] Character character)
        {
            if (id != character.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(character);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CharacterExists(character.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(character);
        }

        // GET: Characters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Character == null)
            {
                return NotFound();
            }

            var character = await _context.Character
                .FirstOrDefaultAsync(m => m.Id == id);
            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }

        // POST: Characters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Character == null)
            {
                return Problem("Entity set 'BeyondCreatorContext.Character'  is null.");
            }
            var character = await _context.Character.FindAsync(id);
            if (character != null)
            {
                _context.Character.Remove(character);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CharacterExists(int id)
        {
            return _context.Character.Any(e => e.Id == id);
        }

        //Создаем документ Сохранения PDF файла



        //[Route("Characters/Details/{id?}")]
        //[HttpPost]
        public async Task<IActionResult> CreatePDFDocument(int? id)
        {
            //Проверка на null
            if (id == null || _context.Character == null)
            {
                return NotFound();
            }

            var character = await _context.Character
                .FirstOrDefaultAsync(m => m.Id == id);
            if (character == null)
            {
                return NotFound();
            }


            //Указываем путь к файлу
            FileStream docStream = new FileStream("C:\\Users\\user\\source\\repos\\BeyondCreator\\BeyondCreator\\wwwroot\\Files\\PDF\\CharacterSheet.pdf", FileMode.Open, FileAccess.Read);
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);
            //loading
            PdfLoadedForm form = loadedDocument.Form;
            //заполняем данные из файла
            //1 — атрибуты
            /* #region attrcheck
              string str = " ";
              string dex = " ";
              string per = " ";
              string cha = " ";
              string int1 = " ";
              string vit = " ";
              if (character.s != null)
              {
                  NameCheck = character.Name.ToString();
              }
              if (character.Race != null)
              {
                  RaceCheck = character.Race.ToString();
              }
         #endregion */



            (form.Fields["CharStrenght"] as PdfLoadedTextBoxField).Text = character.Strenght.ToString();
            (form.Fields["CharDexterity"] as PdfLoadedTextBoxField).Text = character.Dexterity.ToString() ?? " ";
            (form.Fields["CharPerseption"] as PdfLoadedTextBoxField).Text = character.Perseption.ToString() ?? " ";
            (form.Fields["CharCharisma"] as PdfLoadedTextBoxField).Text = character.Charisma.ToString() ?? " ";
            (form.Fields["CharInteligence"] as PdfLoadedTextBoxField).Text = character.Intellegence.ToString() ?? " ";
            (form.Fields["CharVitality"] as PdfLoadedTextBoxField).Text = character.Vitality.ToString() ?? " ";
            //Уровень и опыт
            (form.Fields["CharLvl"] as PdfLoadedTextBoxField).Text = character.Lvl.ToString() ?? " ";
            (form.Fields["CharExp"] as PdfLoadedTextBoxField).Text = character.Experience.ToString() ?? " ";
            //Имя и раса
            //Проверка имени и расы
            /* #region nameracecheck
             string NameCheck = " ";
             string RaceCheck = " ";
             if (character.Name != null)
             {
                 NameCheck = character.Name.ToString();
             }
             if (character.Race != null)
             {
                 RaceCheck = character.Race.ToString();
             }
             #endregion */
            (form.Fields["CharRace"] as PdfLoadedTextBoxField).Text = character.Race.ToString();
            (form.Fields["CharName"] as PdfLoadedTextBoxField).Text = character.Name.ToString();
            //Воля
            (form.Fields["CharWill"] as PdfLoadedTextBoxField).Text = character.Will.ToString() ?? " ";
            //Доспех
            (form.Fields["CharHeadArmour"] as PdfLoadedTextBoxField).Text = character.HeadArmour.ToString() ?? " ";
            (form.Fields["CharBodyArmour"] as PdfLoadedTextBoxField).Text = character.BodyArmour.ToString() ?? " ";
            (form.Fields["CharHandsArmour"] as PdfLoadedTextBoxField).Text = character.ArmsArmour.ToString() ?? " ";
            (form.Fields["CharLegsArmour"] as PdfLoadedTextBoxField).Text = character.LegsArmour.ToString() ?? " ";
            //Преимущества

            //Проверка преимущества
            #region advantages check
            /* string adv1 = " ";
             if (character.Advantage1 != null)
             {
                 adv1 = character.Advantage1.ToString();
             }
             string adv2 = " ";
             if (character.Advantage2 != null)
             {
                 adv2 = character.Advantage2.ToString();
             }
             string adv3 = " ";
             if (character.Advantage3 != null)
             {
                 adv3 = character.Advantage3.ToString();
             }*/
            #endregion
            (form.Fields["CharAdvantage1"] as PdfLoadedTextBoxField).Text = character.Advantage1.ToString();
            (form.Fields["CharAdvantage2"] as PdfLoadedTextBoxField).Text = character.Advantage2.ToString();
            (form.Fields["CharAdvantage3"] as PdfLoadedTextBoxField).Text = character.Advantage3.ToString();
            //Недостатки
            //Проверка недостатков
            /* #region disadvantages check
             string dis1 = " ";
             if (character.Disadvantage1 != null)
             {
                 dis1 = character.Advantage1.ToString();
             }
             string dis2 = " ";
             if (character.Disadvantage2 != null)
             {
                 dis2 = character.Advantage2.ToString();
             }
             string dis3 = " ";
             if (character.Disadvantage3 != null)
             {
                 dis3 = character.Advantage3.ToString();
             }
             #endregion */
            (form.Fields["CharDisadvantage1"] as PdfLoadedTextBoxField).Text = character.Disadvantage1.ToString();
            (form.Fields["CharDisadvantage2"] as PdfLoadedTextBoxField).Text = character.Disadvantage2.ToString();
            (form.Fields["CharDisadvantage3"] as PdfLoadedTextBoxField).Text = character.Disadvantage3.ToString();
            //профессии
            (form.Fields["CharProfession1"] as PdfLoadedTextBoxField).Text =character.Profession1.ToString();
            (form.Fields["CharProfession2"] as PdfLoadedTextBoxField).Text =character.Profession2.ToString();
            (form.Fields["CharProfession3"] as PdfLoadedTextBoxField).Text =character.Profession3.ToString();
            //Пишем документ в поток
            MemoryStream stream = new MemoryStream();
            loadedDocument.Save(stream);
            //Ставим позицию потока в 0
            stream.Position = 0;
            //Закрываем документ
            loadedDocument.Close(true);
            //Определяем тип контента для файла
            string contentType = "application/pdf";
            //Определяем имя файла
            string filename = "Character.pdf";
            //создаём FileContentResult
            return File(stream, contentType, filename);
        }

    }
}