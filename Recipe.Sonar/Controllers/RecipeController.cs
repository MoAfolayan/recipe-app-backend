using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using rec = Recipe.Data.Entities;
using Recipe.Logic.Services.Interfaces;

namespace Recipe.Sonar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly ILogger<RecipeController> _logger;
        private readonly IRecipeService _recipeService;

        public RecipeController(ILogger<RecipeController> logger,
            IRecipeService recipeService)
        {
            _logger = logger;
            _recipeService = recipeService;
        }

        [HttpGet("{id}")]
        [Authorize("read:non-user-entities")]
        public IActionResult Get(int id)
        {
            var recipe = _recipeService.GetById(id);
            return Ok(recipe);
        }

        [HttpPost]
        [Authorize("create:non-user-entities")]
        public IActionResult Add([FromBody] rec.Recipe recipe)
        {
            _recipeService.Add(recipe);
            return Ok();
        }

        [HttpPut]
        [Authorize("update:non-user-entities")]
        public IActionResult Update([FromBody] rec.Recipe recipe)
        {
            _recipeService.Update(recipe);
            return Ok();
        }

        [HttpDelete]
        [Authorize("delete:non-user-entities")]
        public IActionResult Delete([FromBody] rec.Recipe recipe)
        {
            _recipeService.Delete(recipe);
            return Ok();
        }

        [HttpGet("user/{userId}")] 
        [Authorize("read:non-user-entities")]
        public IActionResult GetAllUserRecipesByUserId(int userId)
        {
            var recipes = _recipeService.GetAllUserRecipesByUserId(userId);
            return Ok(recipes);
        }
    }
}
