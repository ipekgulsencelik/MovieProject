﻿namespace Movie.Application.Features.CQRS.Commands.CategoryCommands
{
    public class HideCategoryCommand
    {
        public HideCategoryCommand(int categoryID)
        {
            CategoryID = categoryID;
        }

        public int CategoryID { get; set; }
    }
}