using System;
using AutoFixture;
using HtmlBuilderDemo.Models;
using HtmlBuilderDemo.Services;

namespace HtmlBuilderDemo
{
    static class Program
    {
        private static readonly Fixture fixture = new Fixture();
        
        static void Main(string[] args)
        {
            var form = fixture.Create<Form>();

            var builder = new HtmlBuilder();

            var html = builder.Build(form);
        }
    }
}
