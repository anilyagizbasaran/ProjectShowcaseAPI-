using Business.Abstract;
using Business.Validation;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProjectManager : IProjectService
    {
        private readonly IProjectDal _projectDal;


        public ProjectManager(IProjectDal projectDal)
        {
            _projectDal = projectDal;
        }

        public void AddProject(Project project)
        {
            
            _projectDal.Add(project);
            
        }

        public bool DeleteProject(int id)
        {
            try
            {
                var project = _projectDal.Get(p => p.ProjectId == id);
                if (project == null) return false;
                
                _projectDal.Delete(project);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Project> GetAllProjects()
        {
            var project = _projectDal.GetAll();
            return project;
        }

        public Project GetProjectById(int id)
        {
            var project = _projectDal.Get(p => p.ProjectId == id);
            return project;
        }

        public Dictionary<string, int> GetTechnologyCounts()
        {
            var projects = _projectDal.GetAll(); 
            var technologyList = projects
                .SelectMany(p => p.Technologies.Split(',', StringSplitOptions.TrimEntries)) // split technologies
                .GroupBy(t => t) 
                .ToDictionary(g => g.Key, g => g.Count()); //make dictionary
            if(technologyList.ContainsKey("")) technologyList.Remove(""); // remove empty string

            return technologyList;
        }

        public Project UpdateProject(Project project)
        {
            _projectDal.Update(project);
            return project;
        }
    }
}
