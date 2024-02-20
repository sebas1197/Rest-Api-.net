
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;


    public class TaskRepository
    {
    private readonly Tasks _context; 

    public TaskRepository(Tasks context)
    {
        _context = context;
    }

    public List<ModelTask> GetAll()
    {
        return _context.Tasks2.ToList();
    }

    public void Create(ModelTask task)
    {
        if (task == null)
            throw new ArgumentNullException(nameof(task));

        _context.Tasks2.Add(task);
        _context.SaveChanges();
    }

    public void Update(int id,ModelTask task)
    {
        if (task == null)
            throw new ArgumentNullException(nameof(task));

        if (_context.Tasks2.Find(id) != null)
        {
            _context.Tasks2.Update(task);
            _context.SaveChanges();
        }
    }

    public void Delete(int id, ModelTask task)
    {
        if (task == null)
            throw new ArgumentNullException(nameof(task));

        if(_context.Tasks2.Find(id) != null)
        {
            _context.Tasks2.Remove(task);
            _context.SaveChanges();
        }
    }
}
