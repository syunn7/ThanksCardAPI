using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThanksCardAPI.Models;

namespace ThanksCardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThanksCardsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ThanksCardsController(ApplicationContext context)
        {
            _context = context;
        }

        #region GetThanksCards
        // GET: api/ThanksCards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ThanksCard>>> GetThanksCards()
        {
            // Include を指定することで From, To (Userモデル) を同時に取得する。
            return await _context.ThanksCards
                                    .Include(ThanksCard => ThanksCard.From)
                                    .Include(ThanksCard => ThanksCard.To)
                                    .Include(ThanksCard => ThanksCard.ThanksCardClassifications)
                                        .ThenInclude(ThanksCardClassification => ThanksCardClassification.classification)
                                    .ToListAsync();
        }
        #endregion

        // POST: api/ThanksCards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ThanksCard>> Post([FromBody] ThanksCard thanksCard)
        {
            _context.ThanksCards.Add(thanksCard);
            await _context.SaveChangesAsync();
            // TODO: Error Handling
            return thanksCard;
        }

        [HttpDelete("{id}")]//これがないとスワッガーでエラーが起きる
        public async Task<ActionResult> DeleteThanksCard(long id)
        {
            var thankscard = await _context.ThanksCards.FindAsync(id);//指定したIDを持つ感謝カードを探す
            if (thankscard == null)//そのIDがなかったら404を返す
            {
                return NotFound();
            }

            _context.ThanksCards.Remove(thankscard);//指定したIDの感謝カードを削除する
            await _context.SaveChangesAsync();//処理を保存する(これがないと削除されないです)
            return NoContent();
        }
    }
}
