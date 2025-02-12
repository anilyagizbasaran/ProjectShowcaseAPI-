using Business.Abstract;
using Entities.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace ownWebsite.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : Controller
    {
        

        private readonly IProjectService _projectService;
        private readonly IValidator<Project> _validator;
        public ProjectsController(IProjectService projectService, IValidator<Project> validator)
        {
            _projectService = projectService;
            _validator = validator;
        }

        [HttpPost]
        public IActionResult AddProject([FromBody] Project project)
        {
            var validationResult = _validator.Validate(project);

            if (!validationResult.IsValid)
            {
                return BadRequest(new
                {
                    errors = validationResult.Errors.Select(e => new
                    {
                        propertyName = e.PropertyName,
                        errorMessage = e.ErrorMessage
                    })
                });
            }

            _projectService.AddProject(project);
            return Ok("Proje başarıyla eklendi.");
        }

        [HttpGet]
        public IActionResult GetAllProjects()
        {
            var projects = _projectService.GetAllProjects();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public IActionResult GetProjectById(int id)
        {
            var project = _projectService.GetProjectById(id);
            if (project == null)
            {
                return NotFound("Proje bulunamadı.");
            }
            return Ok(project);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProject(int id, [FromBody] Project project)
        {
            if (project == null || id != project.ProjectId)
            {
                return BadRequest("Geçersiz proje bilgileri.");
            }

            var updatedProject = _projectService.UpdateProject(project);
            if (updatedProject == null)
            {
                return NotFound("Güncellenecek proje bulunamadı.");
            }
            return Ok("Proje başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProject(int? id)
        {
            if (!id.HasValue || id <= 0)
            {
                return BadRequest("Geçersiz proje ID'si. Lütfen geçerli bir ID girin.");
            }

            var result = _projectService.DeleteProject(id.Value);
            if (!result)
            {
                return NotFound("Silinecek proje bulunamadı.");
            }

            return Ok("Proje başarıyla silindi.");
        }


        [HttpGet]
        [Route("technology-counts")]
        public IActionResult GetTechnologyCounts()
        {
            var technologyCounts = _projectService.GetTechnologyCounts();
            return Ok(technologyCounts);
        }
    }
}
