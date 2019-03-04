﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VotingModelLibrary.Models;

namespace Web.Data
{
    public static class DummyData
    {
        private static ApplicationDbContext _context;

        public static async Task Initialize(ApplicationDbContext context)
        {
            _context = context;

            context.Database.EnsureCreated();

            if (context.Candidates.Any()) { return; }

            var organizations = GetOrganizations().ToArray();
            context.Organizations.AddRange(organizations);
            context.SaveChanges();

            var races = GetRaces().ToArray();
            context.Races.AddRange(races);
            context.SaveChanges();

            var candidates = GetCandidates().ToArray();
            context.Candidates.AddRange(candidates);
            context.SaveChanges();

            var contacts = GetContacts().ToArray();
            context.Contacts.AddRange(contacts);
            context.SaveChanges();

            var candidateRaces = GetCandidateRaces().ToArray();
            context.CandidateRaces.AddRange(candidateRaces);
            context.SaveChanges();

            var ballotIssues = GetBallotIssues().ToArray();
            context.BallotIssues.AddRange(ballotIssues);
            context.SaveChanges();

            var issueOptions = GetIssueOptions().ToArray();
            context.IssueOptions.AddRange(issueOptions);
            context.SaveChanges();
        }

        private static List<Organization> GetOrganizations()
        {
            return new List<Organization>()
            {
                new Organization()
                {
                    Name = "_ORGANIZATION_JASON_LAMARCHE_",
                    Description = "_DESCRIPTION_",
                },
                new Organization()
                {
                    Name = "_ORGANIZATION_MIKE_HANSEN_",
                    Description = "_DESCRIPTION_",
                },
            };
        }

        private static List<Race> GetRaces()
        {
            return new List<Race>
            {
                new Race
                {
                    PositionName = "Mayor",
                    NumberNeeded = 1,
                },
            };
        }

        private static List<Candidate> GetCandidates()
        {
            return new List<Candidate>
            {
                new Candidate
                {
                    FirstName = "Jason",
                    LastName= "Lamarche",
                    Picture = "https://vancouver.ca/plan-your-vote/img/mayor0_large.jpg",
                    Biography = @"Jason Lamarche loves Vancouver and has lived here for 21 years. Jason was born in Ottawa, Ontario.

Jason attended Langara and UBC with eight years experience at TD Bank, HSBC, CIBC. Jason was an executive for Canada's largest retail Cannabis distributor.

Jason has ten years experience in Municipal, Provincial, Federal politics; earning 37,286 votes in 2011 Vancouver Council election.",
                    OrganizationId = 1,
                },
                new Candidate
                {
                    FirstName = "Mike",
                    LastName = "Hansen",
                    Picture = "https://vancouver.ca/plan-your-vote/img/mayor1_large.jpg",
                    Biography = @"Been in housing construction most of my life, truck driver, stock promoter and various other business. Founded the Canadian Hemp Growers Assoc. in 1996. 2005 on record at Senate Committee on national defence saying, ""terrorists"" are smuggling guns/drugs into Canada. 2005 Harm Reduction Pilot Project/monopolizing heroin to save lives, Men On Down Town East Society and Two Ravens Opioid Project.",
                    OrganizationId = 2,
                },
            };
        }

        private static List<Contact> GetContacts()
        {
            return new List<Contact>
            {
                new Contact()
                {
                    CandidateId = 1,
                    ContactMethod = "Tel",
                },
                new Contact()
                {
                    CandidateId = 1,
                    ContactMethod = "Email",
                    ContactValue = "MAYORLAMARCHE@protonmail.com",
                },
                new Contact()
                {
                    CandidateId = 2,
                    ContactMethod = "Tel",
                    ContactValue = "604 700 1652",
                },
                new Contact()
                {
                    CandidateId = 2,
                    ContactMethod = "Email",
                    ContactValue = "mikec.hansen@gmail.com",
                },
            };
        }

        private static List<CandidateRace> GetCandidateRaces()
        {
            return new List<CandidateRace>()
            {
                new CandidateRace()
                {
                    RaceId = 1,
                    CandidateId = 1,
                    PositionName = "Mayor",
                    PlatformInfo = @"If Jason Lamarche is elected Mayor of Vancouver he will use his Democratic support and Executive Powers to impose strict Rent Control with select 1 bedroom rents capped at $500 per month.

Jason will launch new Illegal Immigration Control Enforcement teams managed by Vancouver Police Department.

Jason will help Canadian citizens start, run, and expand small businesses and other development projects.

Jason is a true independent and will not accept donations from voters or businesses.",
                    TopIssues = @"RENT CONTROL 1 BR $500
ILLEGAL MIGRANT CONTROL
//PRO SMALL CANADA BUSINESS",
                },
            };
        }

        private static List<BallotIssue> GetBallotIssues()
        {
            return new List<BallotIssue>()
            {
                new BallotIssue()
                {
                    BallotIssueTitle = "TRANSPORTATION AND TECHNOLOGY",
                    Description = @"This question seeks authority to borrow funds to be used in carrying out the basic capital works program with respect to transportation and technology.

Are you in favour of Council having the authority, without further assent of the electors, to pass bylaws between January 1, 2019, and December 31, 2022, to borrow an aggregate $100,353,000 for the following purposes?",
                },
                new BallotIssue()
                {
                    BallotIssueTitle = "CAPITAL MAINTENANCE AND RENOVATION PROGRAMS FOR EXISTING COMMUNITY FACILITIES, CIVIC FACILITIES, AND PARKS",
                    Description = @"This question seeks authority to borrow funds to be used in carrying out the basic capital works program with respect to capital maintenance and renovation programs for existing community facilities, civic facilities, and parks.

Are you in favour of Council having the authority, without further assent of the electors, to pass bylaws between January 1, 2019, and December 31, 2022, to borrow an aggregate $99,557,000 for the following purposes?",
                },
            };
        }

        private static List<IssueOption> GetIssueOptions()
        {
            return new List<IssueOption>()
            {
                new IssueOption()
                {
                    BallotIssueId = 1,
                    IssueOptionTitle = "How you plan to answer Question 1. Transportation and technology",
                    IssueOptionInfo = "Yes",
                },
                new IssueOption()
                {
                    BallotIssueId = 1,
                    IssueOptionTitle = "How you plan to answer Question 1. Transportation and technology",
                    IssueOptionInfo = "No",
                },
                new IssueOption()
                {
                    BallotIssueId = 2,
                    IssueOptionTitle = "How you plan to answer Question 2. Capital maintenance and renovation programs for existing community facilities, civic facilities, and parks",
                    IssueOptionInfo = "Yes",
                },
                new IssueOption()
                {
                    BallotIssueId = 2,
                    IssueOptionTitle = "How you plan to answer Question 2. Capital maintenance and renovation programs for existing community facilities, civic facilities, and parks",
                    IssueOptionInfo = "No",
                },
            };
        }
    }
}