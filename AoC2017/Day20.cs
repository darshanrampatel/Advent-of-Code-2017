using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;

namespace AoC2017
{
    public static class Day20
    {
        public static int Part1(string input)
        {
            var particlesInput = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList();
            var particles = new Dictionary<int, Particle>();
            for (int i = 0; i < particlesInput.Count; i++)
            {
                var p = particlesInput[i];
                var splits = p.Split("=");
                var pos = splits[1].Split(">")[0].Split("<")[1].Split(",", StringSplitOptions.RemoveEmptyEntries);
                var vel = splits[2].Split(">")[0].Split("<")[1].Split(",", StringSplitOptions.RemoveEmptyEntries);
                var acc = splits[3].Split(">")[0].Split("<")[1].Split(",", StringSplitOptions.RemoveEmptyEntries);

                var part = new Particle()
                {
                    Position = new Vector3(float.Parse(pos[0]), float.Parse(pos[1]), float.Parse(pos[2])),
                    Velocity = new Vector3(float.Parse(vel[0]), float.Parse(vel[1]), float.Parse(vel[2])),
                    Acceleration = new Vector3(float.Parse(acc[0]), float.Parse(acc[1]), float.Parse(acc[2]))
                };
                particles.Add(i, part);
            }

            for (int i = 0; i < 10000; i++)//TODO need to decide how long to run this for?
            {
                for (int j = 0; j < particles.Count; j++)
                {
                    particles[j] = ParticleTick(particles[j]);
                }
            }
            return particles.OrderBy(p => p.Value.Distance).First().Key;
        }

        private static Particle ParticleTick(Particle particle)
        {
            particle.Velocity = new Vector3(particle.Velocity.X + particle.Acceleration.X, particle.Velocity.Y + particle.Acceleration.Y, particle.Velocity.Z + particle.Acceleration.Z);
            particle.Position = new Vector3(particle.Position.X + particle.Velocity.X, particle.Position.Y + particle.Velocity.Y, particle.Position.Z + particle.Velocity.Z);
            return particle;
        }

        public static int Part2(string input)
        {
            var particlesInput = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList();
            var particles = new Dictionary<int, Particle>();
            for (int i = 0; i < particlesInput.Count; i++)
            {
                var p = particlesInput[i];
                var splits = p.Split("=");
                var pos = splits[1].Split(">")[0].Split("<")[1].Split(",", StringSplitOptions.RemoveEmptyEntries);
                var vel = splits[2].Split(">")[0].Split("<")[1].Split(",", StringSplitOptions.RemoveEmptyEntries);
                var acc = splits[3].Split(">")[0].Split("<")[1].Split(",", StringSplitOptions.RemoveEmptyEntries);

                var part = new Particle()
                {
                    Position = new Vector3(float.Parse(pos[0]), float.Parse(pos[1]), float.Parse(pos[2])),
                    Velocity = new Vector3(float.Parse(vel[0]), float.Parse(vel[1]), float.Parse(vel[2])),
                    Acceleration = new Vector3(float.Parse(acc[0]), float.Parse(acc[1]), float.Parse(acc[2]))
                };
                particles.Add(i, part);
            }
            var origCount = particles.Count;
            for (int i = 0; i < 10000; i++)//TODO need to decide how long to run this for?
            {
                for (int j = 0; j < origCount; j++)
                {
                    if (particles.ContainsKey(j))
                    {
                        particles[j] = ParticleTick(particles[j]);
                    }
                }
                var collidedParticles = particles.GroupBy(p => p.Value.Position).ToList();
                foreach (var collision in collidedParticles)
                {
                    if (collision.Count() > 1)
                    {
                        particles = particles.Where(p => p.Value.Position != collision.Key).ToDictionary(p => p.Key, p => p.Value);
                    }
                }
            }
            return particles.Count;
        }

        public static void Run()
        {
            Console.WriteLine();
            var day = MethodBase.GetCurrentMethod().DeclaringType.Name;
            Console.WriteLine(day);
            try
            {
                var input = File.ReadAllText($"{day}.txt");
                Console.WriteLine($"{nameof(Part1)}: {Part1(input)}");
                Console.WriteLine($"{nameof(Part2)}: {Part2(input)}");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Could not find input file!");
            }
        }

        private class Particle
        {
            public Vector3 Position { get; set; }
            public Vector3 Acceleration { get; set; }
            public Vector3 Velocity { get; set; }

            public float Distance => Math.Abs(Position.X) + Math.Abs(Position.Y) + Math.Abs(Position.Z);
        }
    }
}
