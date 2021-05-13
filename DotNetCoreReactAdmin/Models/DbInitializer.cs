using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreReactAdmin.Models;

namespace DotNetCoreReactAdmin.Models
{
    public class DbInitializer
    {
        public static void Initialize(DotNetCoreReactAdminContext context)
        {
            if (context.User.Any())
            {
                return;
            }

            var users = new User[]
            {
                new User { Name = "Taro Yamada", Age = 25, Email = "aaa@test.co.jp", Phone = "111-0000-222", Website = "sample-001-test.co.jp" },
                new User { Name = "Jiro Sato", Age = 20, Email = "aaa@test.co.jp", Phone = "111-1111-222", Website = "sample-002-test.co.jp" },
                new User { Name = "Saburo Tanaka", Age = 18, Email = "aaa@test.co.jp", Phone = "111-2222-222", Website = "sample-003-test.co.jp" },
                new User { Name = "Shiro Suzuki", Age = 22, Email = "aaa@test.co.jp", Phone = "111-3333-222", Website = "sample-004-test.co.jp" },
                new User { Name = "Goro Tanaka", Age = 31, Email = "aaa@test.co.jp", Phone = "111-4444-222", Website = "sample-005-test.co.jp" },
                new User { Name = "Taro Takahashi", Age = 29, Email = "aaa@test.co.jp", Phone = "111-5555-222", Website = "sample-006-test.co.jp" },
                new User { Name = "Jiro Ito", Age = 15, Email = "aaa@test.co.jp", Phone = "111-6666-222", Website = "sample-007-test.co.jp" },
                new User { Name = "Saburo Watanabe", Age = 45, Email = "aaa@test.co.jp", Phone = "111-7777-222", Website = "sample-008-test.co.jp" },
                new User { Name = "Shiro Yamamoto", Age = 62, Email = "aaa@test.co.jp", Phone = "111-8888-222", Website = "sample-009-test.co.jp" },
                new User { Name = "Goro Nakamura", Age = 54, Email = "aaa@test.co.jp", Phone = "111-9999-222", Website = "sample-010-test.co.jp" },
                new User { Name = "Taro Kobahashi", Age = 92, Email = "aaa@test.co.jp", Phone = "111-0291-222", Website = "sample-011-test.co.jp" },
                new User { Name = "Jiro Kato", Age = 32, Email = "aaa@test.co.jp", Phone = "111-8920-222", Website = "sample-012-test.co.jp" },
                new User { Name = "Saburo Yoshida", Age = 43, Email = "aaa@test.co.jp", Phone = "111-8390-222", Website = "sample-013-test.co.jp" },
                new User { Name = "Shiro Sasaki", Age = 52, Email = "aaa@test.co.jp", Phone = "111-2816-222", Website = "sample-014-test.co.jp" },
                new User { Name = "Goro Yamaguchi", Age = 77, Email = "aaa@test.co.jp", Phone = "111-2097-222", Website = "sample-015-test.co.jp" },
                new User { Name = "Taro Matsunomoto", Age = 65, Email = "aaa@test.co.jp", Phone = "111-7733-222", Website = "sample-016-test.co.jp" },
                new User { Name = "Jiro Inoue", Age = 42, Email = "aaa@test.co.jp", Phone = "111-9302-222", Website = "sample-001-test.co.jp" },
                new User { Name = "Shiro Kimura", Age = 26, Email = "aaa@test.co.jp", Phone = "111-1209-222", Website = "sample-017-test.co.jp" },
                new User { Name = "Saburo Hayashi", Age = 24, Email = "aaa@test.co.jp", Phone = "111-0398-222", Website = "sample-018-test.co.jp" },
                new User { Name = "Goro Saito", Age = 20, Email = "aaa@test.co.jp", Phone = "111-0987-222", Website = "sample-019-test.co.jp" },
            };

            foreach (var user in users)
            {
                context.User.Add(user);
            }
            context.SaveChanges();
        }
    }
}
