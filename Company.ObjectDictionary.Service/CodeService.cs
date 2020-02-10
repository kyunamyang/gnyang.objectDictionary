using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using AutoMapper;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Company.ObjectDictionary.Common;
using Company.ObjectDictionary.Entity;
using Company.ObjectDictionary.ViewModel;
using Company.ObjectDictionary.Service.Interface;
using Company.ObjectDictionary.Repository.Interface;

namespace Company.ObjectDictionary.Service
{
    public class CodeService : ServiceBase, ICodeService<ModelViewModel>
    {
        private readonly ICodeService<ModelViewModel> generateCodeService;

        public CodeService(ICodeService<ModelViewModel> generateCodeService)
        {
            this.generateCodeService = generateCodeService;
        }

        public string GetClassDefinition(ModelViewModel m)
        {
            var classDeclaration = SyntaxFactory.ClassDeclaration(m.Name)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword));

            var propertyDeclarations = new List<MemberDeclarationSyntax>();

            foreach (var p in m.Fields)
            {
                var propertyDeclaration = SyntaxFactory.PropertyDeclaration(SyntaxFactory.ParseTypeName(p.Type), p.Name)
                    .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                    .AddAccessorListAccessors(SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)))
                    .AddAccessorListAccessors(SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)));

                propertyDeclarations.Add(propertyDeclaration);
            }

            classDeclaration = classDeclaration.AddMembers(propertyDeclarations.ToArray());
            
            return classDeclaration.NormalizeWhitespace()
                .ToFullString();

        }
    }
}
