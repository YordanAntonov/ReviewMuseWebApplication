namespace ReviewMuse.Data.EntityConfigurations
{
    using System.Globalization;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using ReviewMuse.Data.Models;

    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(this.GenerateBooks());

            builder
                .HasOne(e => e.Editor)
                .WithMany(e => e.EditorBooks)
                .HasForeignKey(e => e.EditorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(bc => bc.BookCover)
                .WithMany(bc => bc.BookCovers)
                .HasForeignKey(bc => bc.BookCoverId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(l => l.Language)
                .WithMany(l => l.BooksLanguages)
                .HasForeignKey(l => l.LanguageId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private Book[] GenerateBooks()
        {
            ICollection<Book> books = new HashSet<Book>();

            Book book;

            book = new Book()
            {
                IsActive = true,
                Title = "The Call of Cthulhu",
                NumberOfPages = 43,
                BookCoverId = 3,
                ISBN = "9786555981087",
                EditorId = Guid.Parse("890D172F-2D04-49AD-AB05-A37525FB0AFE"),
                PublishingDate = DateTime.Parse("1928-02-01", CultureInfo.InvariantCulture),
                LanguageId = 1,
                ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1567470807i/15730101.jpg",
                Description = "\"The Call of Cthulhu\" is a renowned short story written by American author H.P. Lovecraft and published in 1928. It is considered one of Lovecraft's most iconic and influential works, exemplifying his unique brand of cosmic horror.The story revolves around a narrative that unfolds through the eyes of multiple characters, piecing together a dark and chilling mythology. It follows the investigation of a mysterious and disturbing cult, whose worship centers around an ancient and malevolent entity called Cthulhu. As the narrative progresses, the protagonists uncover ancient manuscripts, encounter strange occurrences, and ultimately confront the horrifying truth about Cthulhu's existence and its immense power.\r\n\r\n\"The Call of Cthulhu\" delves into Lovecraft's overarching mythos known as the \"Cthulhu Mythos.\" This interconnected mythology features otherworldly creatures, ancient gods, and the concept of humanity's insignificance in the face of cosmic horrors that lie beyond human comprehension.\r\n\r\nLovecraft's writing style in this story is marked by his ability to build an atmosphere of creeping dread and unease. He employs vivid descriptions, evocative language, and a sense of cosmic vastness to instill a sense of overwhelming terror in the reader.\r\n\r\n\"The Call of Cthulhu\" has had a lasting impact on horror literature and popular culture, influencing subsequent generations of writers and artists. It has become a defining work in the subgenre of cosmic horror, with its themes of forbidden knowledge, ancient evils, and the fragility of human sanity resonating with audiences worldwide.\r\n\r\nThis iconic tale stands as a testament to Lovecraft's mastery of creating an atmosphere of existential horror and remains a cornerstone of his enduring literary legacy."
            };
            books.Add(book);

            book = new Book()
            {
                IsActive = true,
                Title = "The Shadow over Innsmouth",
                NumberOfPages = 158,
                BookCoverId = 2,
                LanguageId = 1,
                PublishingDate = DateTime.Parse("1936-04-01", CultureInfo.InvariantCulture),
                ISBN = "9781450562799",
                EditorId = Guid.Parse("890D172F-2D04-49AD-AB05-A37525FB0AFE"),
                ImageUrl = "https://upload.wikimedia.org/wikipedia/en/e/e0/Shadows_over_innsmouth.jpg",
                Description = "\"The Shadow over Innsmouth\" is a chilling and influential novella written by American author H.P. Lovecraft and published in 1931. It is considered one of Lovecraft's most significant works, showcasing his mastery of atmospheric horror and cosmic dread.\r\n\r\nThe story follows an unnamed narrator who visits the fictional coastal town of Innsmouth, Massachusetts. As the narrator delves deeper into the history and secrets of Innsmouth, he uncovers a sinister and otherworldly truth. The town's inhabitants, known as the Innsmouth folk, are revealed to be part of a hybrid race resulting from interbreeding between humans and an aquatic, otherworldly species called the Deep Ones. The narrator becomes entangled in a web of horror and conspiracy as he learns more about the town's dark rituals, monstrous creatures, and the ancient, eldritch powers that lurk beneath the surface.\r\n\r\nLovecraft's evocative descriptions and detailed world-building bring Innsmouth to life, painting a vivid picture of a decaying town plagued by a hidden, macabre reality. The novella explores themes of forbidden knowledge, the fragility of human perception, and the inherent fear of the unknown. It highlights Lovecraft's overarching cosmic horror, with humanity encountering forces and entities far beyond their comprehension.\r\n\r\n\"The Shadow over Innsmouth\" has had a profound influence on horror literature and has become one of Lovecraft's most celebrated and widely studied works. Its themes, imagery, and atmospheric storytelling have inspired countless authors, filmmakers, and artists, leaving a lasting impact on the genre.\r\n\r\nWith its mix of forbidden secrets, ancient evils, and Lovecraft's signature style of psychological horror, \"The Shadow over Innsmouth\" stands as a testament to the enduring power and lasting legacy of H.P. Lovecraft's contribution to the realm of cosmic horror."
            };
            books.Add(book);

            book = new Book()
            {
                IsActive = true,
                Title = "Dagon and Other Macabre Tales",
                NumberOfPages = 448,
                BookCoverId = 2,
                LanguageId = 1,
                PublishingDate = DateTime.Parse("1917-07-01", CultureInfo.InvariantCulture),
                ISBN = "9788441412996",
                EditorId = Guid.Parse("890D172F-2D04-49AD-AB05-A37525FB0AFE"),
                ImageUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/5/54/Dagon_fifth.jpg/200px-Dagon_fifth.jpg",
                Description = "\"Dagon and Other Macabre Tales\" is a collection of short stories written by the iconic American author, H.P. Lovecraft. Published in 1965, this compilation showcases Lovecraft's prowess in crafting unsettling and atmospheric tales of cosmic horror.\r\n\r\nThe collection takes its name from the opening story, \"Dagon,\" in which an unnamed narrator recounts a harrowing encounter with a nightmarish creature in the depths of the ocean. The story sets the tone for the rest of the collection, as readers are plunged into a world where ancient gods, forbidden knowledge, and unspeakable horrors lurk just beyond the veil of human perception.\r\n\r\nEach story in \"Dagon and Other Macabre Tales\" explores Lovecraft's unique blend of psychological terror, supernatural phenomena, and existential dread. From the crumbling New England towns haunted by dark secrets to the forgotten realms of cosmic entities, Lovecraft's characters face insurmountable forces beyond human comprehension. Whether it's delving into forbidden books, confronting ancient cults, or witnessing the devastating effects of forbidden knowledge, the protagonists find themselves on a treacherous journey where the boundaries of reality are shattered.\r\n\r\nLovecraft's writing style captivates readers with his vivid descriptions, richly imagined settings, and an air of impending doom. The collection showcases his masterful ability to create a sense of overwhelming dread, evoking a lingering unease that resonates long after the stories have been read.\r\n\r\n\"Dagon and Other Macabre Tales\" stands as a testament to Lovecraft's unparalleled legacy in the genre of cosmic horror. The collection's dark and mysterious stories have influenced countless authors, filmmakers, and artists, shaping the landscape of horror literature and inspiring generations of readers to explore the depths of the unknown.\r\n\r\nPrepare to embark on a journey into the shadowed realms of the human psyche and the terrifying forces that lie beyond. \"Dagon and Other Macabre Tales\" invites you to immerse yourself in the captivating and disturbing imagination of H.P. Lovecraft, where ancient terrors and unspeakable truths await those brave enough to venture into the macabre depths."
            };
            books.Add(book);

            book = new Book()
            {
                IsActive = true,
                Title = "Thief of Time",
                NumberOfPages = 378,
                BookCoverId = 2,
                LanguageId = 1,
                ISBN = "9780061031328",
                PublishingDate = DateTime.Parse("2008-01-01", CultureInfo.InvariantCulture),
                EditorId = Guid.Parse("890D172F-2D04-49AD-AB05-A37525FB0AFE"),
                ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1388177603i/48002.jpg",
                Description = "\"Thief of Time\" is a captivating novel written by acclaimed British author Terry Pratchett. Published in 2001, it is the 26th book in the beloved Discworld series, a humorous and fantastical world that Pratchett created.\r\n\r\nIn \"Thief of Time,\" Pratchett weaves a story that revolves around the concept of time itself. The Auditors of Reality, celestial beings who seek to bring order and eliminate chaos, employ a mysterious and enigmatic entity known as Lobsang Ludd. Lobsang Ludd, together with a motley crew of eccentric characters, embarks on a journey to prevent the perfect clock from being built. The creation of this clock could potentially end time as everyone knows it and usher in a new era of order and rigidity.\r\n\r\nAs the plot unfolds, Pratchett tackles profound themes of fate, mortality, and the value of time. He seamlessly combines humor, social commentary, and philosophical insights, all while maintaining his signature wit and clever wordplay. The story explores the nature of time, its influence on individuals and societies, and the choices we make within its constraints.\r\n\r\nPratchett's vibrant characters, including Death, the iconic anthropomorphic personification, and the audacious History Monks, inject the narrative with memorable personalities and delightful interactions. Each character adds depth to the story and presents unique perspectives on the complexities of time.\r\n\r\n\"Thief of Time\" showcases Pratchett's ability to blend fantasy and satire with a thought-provoking narrative. His imaginative world-building transports readers to the Discworld, a realm filled with whimsy, magic, and unexpected twists.\r\n\r\nThrough his sharp observations and compelling storytelling, Pratchett explores the intricacies of time, the human desire to control it, and the importance of embracing life's unpredictability. \"Thief of Time\" is a testament to Pratchett's literary genius, providing both entertainment and profound insights into the human condition.\r\n\r\nPrepare to be whisked away on a rollicking adventure through time and space, as Terry Pratchett's \"Thief of Time\" invites you to ponder the mysteries of existence while reveling in a world brimming with humor and imagination."
            };
            books.Add(book);

            book = new Book()
            {
                IsActive = true,
                Title = "Making Money",
                NumberOfPages = 394,
                BookCoverId = 3,
                LanguageId = 1,
                PublishingDate = DateTime.Parse("2007-09-18", CultureInfo.InvariantCulture),
                ISBN = "9780061161643",
                EditorId = Guid.Parse("890D172F-2D04-49AD-AB05-A37525FB0AFE"),
                ImageUrl = "https://m.media-amazon.com/images/I/91RERCQb4qL._AC_UF894,1000_QL80_.jpg",
                Description = "\"Making Money\" is a delightful and satirical novel penned by the legendary British author Terry Pratchett. Published in 2007, it is the 36th book in the beloved Discworld series, offering a humorous and insightful exploration of the world of finance and commerce.\r\n\r\nIn \"Making Money,\" Pratchett reintroduces readers to the endearing character Moist von Lipwig, who previously graced the pages of \"Going Postal.\" Moist, now reformed from his con artist ways, finds himself thrust into a new role as the Postmaster General of Ankh-Morpork. However, his life takes an unexpected turn when he is appointed as the head of the Royal Bank, challenging Moist to navigate the treacherous world of finance and confront the quirky and often absurd intricacies of the banking industry.\r\n\r\nPratchett skillfully blends wit, clever wordplay, and his trademark satirical style to expose the follies and quirks of economic systems and institutions. Through Moist's misadventures, the narrative explores themes such as the nature of money, greed, and the impact of capitalism on society.\r\n\r\nThe author populates the story with a cast of vibrant and memorable characters, including the formidable Lord Vetinari, the ruler of Ankh-Morpork, and the ever-entertaining Igors. Pratchett's astute observations on human nature and the absurdities of bureaucracy add depth and comedic charm to the narrative.\r\n\r\n\"Making Money\" showcases Pratchett's ability to use fantasy and humor to dissect real-world issues. The story entertains while offering subtle social commentary on the role of money in society and the complexities of the financial world.\r\n\r\nWith his unparalleled storytelling and imaginative world-building, Pratchett transports readers to the vivid and whimsical realm of Discworld, where familiar settings and characters are imbued with fresh perspectives and unexpected twists.\r\n\r\n\"Making Money\" is a testament to Pratchett's literary brilliance, offering a delightful blend of humor, social satire, and thought-provoking insights. Prepare to be enchanted as Terry Pratchett's \"Making Money\" takes you on a rollicking journey through the absurdities and complexities of the financial world, leaving you with laughter and contemplation along the way."
            };
            books.Add(book);

            book = new Book()
            {
                IsActive = true,
                Title = "Monstrous Regiment",
                NumberOfPages = 496,
                BookCoverId = 2,
                LanguageId = 1,
                ISBN = "9783442461950",
                PublishingDate = DateTime.Parse("2003-09-20", CultureInfo.InvariantCulture),
                EditorId = Guid.Parse("890D172F-2D04-49AD-AB05-A37525FB0AFE"),
                ImageUrl = "https://upload.wikimedia.org/wikipedia/en/1/11/Monstrous_regiment.jpg",
                Description = "\"Monstrous Regiment\" is an enthralling and witty novel crafted by the beloved British author Terry Pratchett. Published in 2003, it takes its place as the 31st book in the acclaimed Discworld series, offering a thought-provoking and humorous exploration of gender, war, and identity.\r\n\r\nIn \"Monstrous Regiment,\" Pratchett introduces readers to the determined and resourceful character of Polly Perks. Disguised as a young man, Polly joins the army in order to find her missing brother. As she becomes entangled in the chaos of war, Polly discovers that her fellow soldiers are not quite what they seem. Together, this motley crew challenges traditional notions of gender roles and unravels a web of conspiracy that reaches far beyond the battlefield.\r\n\r\nPratchett's sharp wit and satirical brilliance shine through as he delves into themes of gender inequality, societal expectations, and the absurdities of war. Through the lens of humor and fantasy, he offers insightful commentary on the complexities of identity and the power dynamics that shape our world.\r\n\r\nThe author's expert characterization breathes life into a diverse and memorable cast of characters, including the indomitable Sergeant Jackrum, the enigmatic vampire Maladict, and the irrepressible Igorina. Pratchett skillfully explores their personal journeys, revealing the strengths and vulnerabilities that lie beneath their unconventional facades.\r\n\r\n\"Monstrous Regiment\" exemplifies Pratchett's unique ability to blend social commentary with fantastical storytelling. His masterful wordplay and astute observations create a narrative that entertains and prompts introspection, inviting readers to question societal norms and challenge preconceived notions.\r\n\r\nSet within the vivid and whimsical world of Discworld, \"Monstrous Regiment\" showcases Pratchett's unparalleled imagination and gift for creating richly detailed environments. The novel invites readers to reflect on issues of identity, equality, and the true meaning of courage.\r\n\r\nPrepare to embark on a captivating and thought-provoking adventure as Terry Pratchett's \"Monstrous Regiment\" takes you on a journey that challenges conventions and celebrates the strength of the human spirit. With its blend of humor, social insight, and fantastical storytelling, this novel will leave an indelible mark on your imagination and spark conversations long after the final page is turned."
            };
            books.Add(book);

            book = new Book()
            {
                IsActive = true,
                Title = "The Raven",
                NumberOfPages = 36,
                BookCoverId = 1,
                LanguageId = 1,
                ISBN = "9786586655940",
                PublishingDate = DateTime.Parse("1845-01-29", CultureInfo.InvariantCulture),
                EditorId = Guid.Parse("890D172F-2D04-49AD-AB05-A37525FB0AFE"),
                ImageUrl = "https://m.media-amazon.com/images/I/314q6A3jCNL._AC_UF1000,1000_QL80_.jpg",
                Description = "\"The Raven\" is a renowned narrative poem written by American author Edgar Allan Poe. First published in 1845, it is one of Poe's most famous and enduring works, showcasing his mastery of atmosphere, symbolism, and psychological exploration.\r\n\r\n\"The Raven\" tells the haunting tale of a lonely narrator who is visited by a mysterious talking raven late one night. As the narrator engages in a dialogue with the raven, he descends into a state of increasing anguish and despair, driven by his obsession with his lost love, Lenore. The repetition of the raven's ominous refrain, \"Nevermore,\" echoes through the poem, intensifying the narrator's sense of grief and his descent into madness.\r\n\r\nPoe's poetic style is marked by its musicality, vivid imagery, and the use of repetition and alliteration. He weaves together elements of Gothic horror, the supernatural, and the human psyche to create an atmosphere of melancholy and foreboding. The poem's themes of loss, mourning, and the crushing weight of the past resonate deeply with readers, evoking a sense of universal human experience.\r\n\r\n\"The Raven\" is celebrated for its evocative language and its exploration of the darkest corners of the human mind. Poe's vivid descriptions and rich symbolism engage the reader's senses, immersing them in a world where reality and imagination blur.\r\n\r\nThis iconic poem has had a profound impact on literature and popular culture, inspiring countless adaptations, references, and interpretations. Its timeless themes, haunting imagery, and mesmerizing rhythm have solidified \"The Raven\" as one of the most enduring and haunting works in the English language.\r\n\r\nPrepare to be transported into the depths of despair and the haunting world of Edgar Allan Poe's \"The Raven.\" Immerse yourself in its poetic brilliance and psychological turmoil as you unravel the mysteries and obsessions that linger within its dark and mesmerizing verses."
            };
            books.Add(book);

            book = new Book()
            {
                IsActive = true,
                Title = "Murder on the Orient Express",
                NumberOfPages = 274,
                BookCoverId = 2,
                LanguageId = 1,
                ISBN = "9780007119318",
                PublishingDate = DateTime.Parse("1934-01-01", CultureInfo.InvariantCulture),
                EditorId = Guid.Parse("890D172F-2D04-49AD-AB05-A37525FB0AFE"),
                ImageUrl = "https://lyceumtheatre.org/wp-content/uploads/2019/09/Murder-on-the-Orient-Express-WebPstr.jpg",
                Description = "\"Murder on the Orient Express\" is a gripping and classic detective novel penned by the renowned British author Agatha Christie. Published in 1934, it stands as one of Christie's most famous and beloved works, captivating readers with its intricate plot and unforgettable characters.\r\n\r\nThe story unfolds on the luxurious and legendary train, the Orient Express, during a snowy winter journey. When a murder occurs on board, renowned detective Hercule Poirot finds himself among the passengers and takes on the task of unraveling the perplexing puzzle. As Poirot methodically interviews each passenger, he uncovers a web of secrets, motives, and hidden connections, leading to a climax that will leave readers astonished.\r\n\r\nAgatha Christie's masterful storytelling keeps readers on the edge of their seats as they try to piece together the clues alongside Poirot. The novel showcases Christie's talent for crafting complex plots filled with red herrings and unexpected twists, ultimately leading to a resolution that challenges conventional notions of justice and morality.\r\n\r\n\"Murder on the Orient Express\" not only captivates with its cleverly constructed mystery but also presents a rich tapestry of diverse characters. From the enigmatic and sharp-witted Poirot to the eclectic mix of passengers with their own hidden pasts and motivations, each character brings a unique perspective to the investigation, adding depth and intrigue to the narrative.\r\n\r\nThe novel explores themes of justice, guilt, and the consequences of actions, as Christie delves into the complexities of human nature. With her astute observations and psychological insight, she creates a compelling portrait of a crime and its impact on those involved.\r\n\r\n\"Murder on the Orient Express\" has become an iconic and enduring piece of detective fiction, inspiring numerous adaptations in film, television, and theater. It showcases Agatha Christie's genius as the queen of the mystery genre, and its popularity endures, captivating new generations of readers with its suspenseful atmosphere and brilliant plotting.\r\n\r\nPrepare to embark on a thrilling journey as you step aboard the Orient Express and join Hercule Poirot in his quest for truth. Agatha Christie's \"Murder on the Orient Express\" will keep you guessing until the final reveal, leaving you enthralled and immersed in a world of intrigue, suspense, and the relentless pursuit of justice."
            };
            books.Add(book);

            book = new Book()
            {
                IsActive = true,
                Title = "The Old Man and the Sea",
                NumberOfPages = 96,
                BookCoverId = 3,
                LanguageId = 1,
                ISBN = "9780684830490   ",
                PublishingDate = DateTime.Parse("1952-01-01", CultureInfo.InvariantCulture),
                EditorId = Guid.Parse("890D172F-2D04-49AD-AB05-A37525FB0AFE"),
                ImageUrl = "https://m.media-amazon.com/images/I/71Au8SjrwkL._AC_UF1000,1000_QL80_.jpg",
                Description = "\"The Old Man and the Sea\" is a timeless novella written by American author Ernest Hemingway. Published in 1952, it tells a poignant and introspective tale of determination, resilience, and the human spirit's struggle against nature's forces.\r\n\r\nSet in the Gulf Stream waters off the coast of Cuba, the story follows Santiago, an aging Cuban fisherman who has gone for an extended period without catching a fish. Undeterred by his recent streak of bad luck, Santiago embarks on an arduous journey alone into the open sea, seeking to prove his skill and worth as a fisherman.\r\n\r\nAs Santiago battles the elements and tests his physical and mental limits, he becomes locked in an epic struggle with a massive marlin, a fish of legendary size and strength. The novella explores Santiago's unwavering determination, his solitude, and the profound connection he feels with the natural world.\r\n\r\nHemingway's sparse and evocative prose immerses readers in Santiago's solitary journey, painting a vivid portrait of the ocean's vastness and the hardships faced by the old fisherman. Through Santiago's internal monologues, Hemingway delves into themes of endurance, honor, and the inevitability of age and mortality.\r\n\r\n\"The Old Man and the Sea\" earned Hemingway the Pulitzer Prize for Fiction in 1953 and is revered as one of his finest works. It embodies the author's signature style, characterized by concise and direct language that reflects the stoic determination and quiet strength of his characters.\r\n\r\nThe novella's exploration of universal themes, such as the pursuit of dreams and the resilience of the human spirit, has resonated with readers worldwide. Its enduring appeal lies in its ability to inspire contemplation on the meaning of life, the pursuit of personal excellence, and the inherent struggles faced by individuals in their quest for achievement.\r\n\r\nPrepare to embark on an introspective and emotional journey as Ernest Hemingway's \"The Old Man and the Sea\" takes you into the heart of a fisherman's profound struggle against nature and the indomitable spirit that drives him forward. This timeless tale will leave you reflecting on the triumphs and challenges of the human experience long after you turn the final page."
            };
            books.Add(book);

            book = new Book()
            {
                IsActive = true,
                Title = "The Sun Also Rises",
                NumberOfPages = 189,
                BookCoverId = 2,
                LanguageId = 1,
                ISBN = "9780586044674",
                PublishingDate = DateTime.Parse("1957-01-01", CultureInfo.InvariantCulture),
                EditorId = Guid.Parse("890D172F-2D04-49AD-AB05-A37525FB0AFE"),
                ImageUrl = "https://m.media-amazon.com/images/I/71O7XjXaMhL._AC_UF1000,1000_QL80_.jpg",
                Description = "\"The Sun Also Rises\" is a powerful and groundbreaking novel written by the iconic American author Ernest Hemingway. Published in 1926, it is considered one of Hemingway's most influential works and a defining novel of the Lost Generation.\r\n\r\nSet in the aftermath of World War I, the story centers around a group of disillusioned expatriates, mainly American and British, living in Paris and traveling to Pamplona, Spain, for the running of the bulls. At the heart of the narrative is Jake Barnes, an American journalist wounded during the war, and his complex and turbulent relationship with Lady Brett Ashley, a charismatic and free-spirited Englishwoman.\r\n\r\nThrough vivid descriptions and spare, unadorned prose, Hemingway explores the post-war disillusionment, moral ambiguity, and the search for meaning in a world shattered by violence and upheaval. The characters in \"The Sun Also Rises\" grapple with their own emotional and psychological wounds, attempting to find solace and escape through love, friendship, and the pursuit of pleasure.\r\n\r\nHemingway's narrative style, characterized by its brevity and understatement, captures the essence of the characters and their unspoken desires and frustrations. The novel's poignant dialogue and introspective passages reflect the struggles and inner turmoil of a generation grappling with the lost ideals of war and the difficulty of reestablishing their place in society.\r\n\r\n\"The Sun Also Rises\" is renowned for its exploration of themes such as masculinity, sexuality, the nature of love, and the pursuit of authenticity. Hemingway's portrayal of the bullfighting spectacle serves as a powerful metaphor for the characters' quest for meaning and their confrontation with life's harsh realities.\r\n\r\nThis groundbreaking novel catapulted Hemingway to literary stardom and solidified his reputation as a pioneer of modernist literature. It captured the spirit of an era and remains an enduring work that continues to resonate with readers, offering profound insights into the complexities of human relationships, the scars of war, and the fragility of the human condition.\r\n\r\nPrepare to be swept away by the evocative and introspective journey of Ernest Hemingway's \"The Sun Also Rises.\" This remarkable novel immerses you in a world of post-war disillusionment, passion, and existential questioning, leaving an indelible mark on your understanding of the human experience."
            };
            books.Add(book);

            book = new Book()
            {
                IsActive = true,
                Title = "A Farewell to Arms",
                NumberOfPages = 293,
                BookCoverId = 2,
                LanguageId = 1,
                PublishingDate = DateTime.Parse("1929-09-01", CultureInfo.InvariantCulture),
                ISBN = "9780099910107",
                EditorId = Guid.Parse("890D172F-2D04-49AD-AB05-A37525FB0AFE"),
                ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1313714836i/10799.jpg",
                Description = "\"A Farewell to Arms\" is a poignant and deeply moving novel written by the renowned American author Ernest Hemingway. Published in 1929, it is considered one of Hemingway's greatest literary achievements and a classic of 20th-century literature.\r\n\r\nSet against the backdrop of World War I, the novel follows the experiences of Frederic Henry, an American ambulance driver serving in the Italian army. Through Frederic's eyes, Hemingway portrays the harsh realities of war, the brutality of battle, and the toll it takes on the human spirit.\r\n\r\nAs the story unfolds, Frederic becomes deeply involved in a passionate and ultimately tragic love affair with Catherine Barkley, an English nurse. Their relationship serves as a refuge from the chaos of war, providing moments of tenderness, solace, and fleeting happiness. However, their love is tested by the destructive forces of war, loss, and the uncertainties of their future.\r\n\r\nHemingway's spare and concise prose captures the essence of war and its impact on the characters' lives. Through his signature writing style, he conveys intense emotions, existential contemplation, and the search for meaning in a world marked by violence and despair.\r\n\r\n\"A Farewell to Arms\" explores themes such as love, loyalty, sacrifice, and the futility of war. Hemingway confronts the devastating consequences of human conflict and the disillusionment that arises when faced with the realities of mortality and the fragility of human existence.\r\n\r\nThe novel's power lies in its ability to evoke a range of emotions, from the euphoria of newfound love to the heart-wrenching grief of loss. Hemingway's portrayal of the human spirit in the face of adversity and his examination of the complexities of relationships leave a lasting impact on readers.\r\n\r\n\"A Farewell to Arms\" is not only a haunting war novel but also a profound meditation on the human condition. Hemingway's portrayal of love and war, with its themes of longing, hope, and the search for meaning, solidifies the novel as a timeless work of literature that continues to resonate with readers across generations.\r\n\r\nPrepare to be transported to the trenches of World War I and embark on an emotional journey through love, loss, and the indomitable spirit of the human heart with Ernest Hemingway's \"A Farewell to Arms.\" This remarkable novel will leave an indelible mark on your soul, reminding you of the enduring power of love and the haunting consequences of war."
            };
            books.Add(book);

            book = new Book()
            {
                IsActive = true,
                Title = "The Shining",
                NumberOfPages = 659,
                BookCoverId = 2,
                LanguageId = 1,
                ISBN = "9780450040184",
                PublishingDate = DateTime.Parse("1977-01-28"),
                EditorId = Guid.Parse("890D172F-2D04-49AD-AB05-A37525FB0AFE"),
                ImageUrl = "https://m.media-amazon.com/images/I/71oXpXeWbML._AC_UF894,1000_QL80_.jpg",
                Description = "\"The Shining\" is a chilling and iconic novel written by the master of horror, Stephen King. Published in 1977, it is considered one of King's most terrifying and psychologically gripping works, immersing readers in a world where supernatural forces collide with the fragile human psyche.\r\n\r\nThe story centers around the Torrance family: Jack, Wendy, and their young son, Danny. Jack, a struggling writer, accepts a job as the winter caretaker of the remote Overlook Hotel in Colorado. The family moves into the hotel, hoping for a fresh start. However, as the harsh winter isolates them and the hotel's dark past begins to reveal itself, they become trapped in a nightmare from which there may be no escape.\r\n\r\n\"The Shining\" delves into the depths of human madness, exploring themes of isolation, addiction, and the inherent evil that lies dormant in both the physical and metaphysical realms. King's expert storytelling immerses readers in a haunting atmosphere, where the lines between reality and the supernatural blur, and the hotel itself becomes a malevolent character.\r\n\r\nThrough his vivid descriptions and deep characterizations, King unveils the psychological breakdown of Jack Torrance, whose descent into madness threatens the lives of his family. Young Danny possesses a unique psychic ability called \"the shining,\" which becomes both a source of terror and a means of survival as he navigates the hotel's malevolence.\r\n\r\n\"The Shining\" is a masterclass in suspense and psychological horror. King's ability to tap into universal fears and anxieties, coupled with his rich storytelling and immersive world-building, creates an atmosphere of relentless terror and unease that lingers long after the final page is turned.\r\n\r\nThe novel has had a significant impact on popular culture, inspiring a highly acclaimed film adaptation by Stanley Kubrick and influencing subsequent generations of horror writers. Its exploration of the fragility of the human mind and the enduring power of evil has solidified \"The Shining\" as a cornerstone of the horror genre.\r\n\r\nPrepare to be consumed by the relentless and bone-chilling terror of Stephen King's \"The Shining.\" This mesmerizing novel will transport you to the heart of madness, where the boundaries of reality and the supernatural blur, leaving you gripped by fear and forever haunted by the horrors that lurk within."
            };
            books.Add(book);

            book = new Book()
            {
                IsActive = true,
                Title = "The Green Mile",
                NumberOfPages = 592,
                BookCoverId = 2,
                LanguageId = 1,
                ISBN = "9780451933027",
                PublishingDate = DateTime.Parse("1996-01-01", CultureInfo.InvariantCulture),
                EditorId = Guid.Parse("890D172F-2D04-49AD-AB05-A37525FB0AFE"),
                ImageUrl = "https://d28hgpri8am2if.cloudfront.net/book_images/onix/cvr9781501192265/the-green-mile-9781501192265_hr.jpg",
                Description = "\"The Green Mile\" is a compelling and emotionally charged novel written by acclaimed author Stephen King. Originally published in 1996 as a serial novel, it captivates readers with its powerful storytelling and exploration of human nature, morality, and compassion.\r\n\r\nSet in the 1930s, the story takes place in a fictional Louisiana State Penitentiary called Cold Mountain Penitentiary, referred to as \"The Green Mile\" due to the color of the floor leading to the execution chamber. The narrative follows the experiences of the prison staff, particularly Paul Edgecombe, the head guard, as they encounter a unique inmate named John Coffey.\r\n\r\nJohn Coffey, a physically imposing black man with a gentle demeanor, possesses extraordinary healing powers. As Paul and his fellow guards witness John's abilities, they grapple with their own beliefs, prejudices, and the profound impact of John's presence on their lives. The story unfolds as they confront questions of morality, justice, and the nature of good and evil.\r\n\r\nKing masterfully weaves together elements of supernatural and historical fiction, blending them with profound human drama. Through vivid characterizations, he explores the complexities of the human condition and challenges societal perceptions of right and wrong.\r\n\r\n\"The Green Mile\" is not merely a story about life on death row; it delves into profound themes such as empathy, redemption, and the power of compassion in the face of cruelty and injustice. The novel examines the lengths to which individuals can go to find solace, understanding, and a sense of purpose in a world filled with pain and suffering.\r\n\r\nKing's rich descriptions and evocative prose draw readers into the prison's stifling atmosphere and the emotional turmoil of the characters. He expertly combines suspense, heartache, and moments of unexpected beauty to create a narrative that resonates long after the final page is turned.\r\n\r\n\"The Green Mile\" has garnered critical acclaim and a devoted following. It was adapted into a highly successful film in 1999, further solidifying its impact on popular culture. Through its powerful storytelling and exploration of the human spirit, Stephen King's \"The Green Mile\" offers an unforgettable journey into the depths of the human heart, leaving readers profoundly moved and forever changed."
            };
            books.Add(book);

            book = new Book()
            {
                IsActive = true,
                Title = "It",
                NumberOfPages = 1168,
                BookCoverId = 2,
                LanguageId = 1,
                ISBN = "9780450411434",
                PublishingDate = DateTime.Parse("1986-09-15", CultureInfo.InvariantCulture),
                EditorId = Guid.Parse("890D172F-2D04-49AD-AB05-A37525FB0AFE"),
                ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1334416842i/830502.jpg",
                Description = "\"IT\" is a monumental and chilling novel written by the master of horror, Stephen King. Originally published in 1986, it is a sprawling and epic tale that weaves together elements of supernatural horror, coming-of-age drama, and the exploration of childhood fears.\r\n\r\nSet in the fictional town of Derry, Maine, \"IT\" follows a group of childhood friends known as the Losers' Club. As children, they encounter a malevolent entity that takes the form of Pennywise the Dancing Clown, a creature that preys on their deepest fears. They make a pact to face this ancient evil, but as they grow up and go their separate ways, they believe their nightmare is over.\r\n\r\nHowever, when mysterious disappearances and gruesome murders plague Derry years later, the Losers' Club, now adults, are called back to fulfill their childhood promise and confront the terrifying force they thought they had defeated.\r\n\r\nKing expertly crafts a multi-layered narrative that delves into the power of memory, the enduring trauma of childhood, and the battle between good and evil. Through vivid descriptions, intricate character development, and a sense of creeping dread, he explores the darkest corners of the human psyche and the resilience of the human spirit in the face of unimaginable horrors.\r\n\r\nThe novel deftly tackles themes of friendship, trauma, the loss of innocence, and the cyclical nature of fear. King's prose is both immersive and evocative, creating an atmosphere of pervasive dread that lingers long after the book is closed.\r\n\r\n\"IT\" is an exploration of the nature of fear itself, as well as the power of imagination and belief to combat it. Through the character of Pennywise, King taps into primal fears and exposes the vulnerabilities of both children and adults alike.\r\n\r\nWith its blend of psychological terror, supernatural elements, and an unforgettable cast of characters, \"IT\" stands as a testament to Stephen King's storytelling prowess. The novel has become a cultural phenomenon, inspiring a successful miniseries in 1990 and a highly acclaimed film adaptation in 2017.\r\n\r\nPrepare to be captivated and terrified as you journey into the dark and twisted world of Stephen King's \"IT.\" This epic and haunting novel will immerse you in a nightmarish realm where childhood fears manifest, secrets lurk in the shadows, and the line between reality and nightmare blurs."
            };
            books.Add(book);

            book = new Book()
            {
                IsActive = true,
                Title = "Under the Yoke",
                NumberOfPages = 306,
                BookCoverId = 2,
                LanguageId = 2,
                ISBN = "9781784350550",
                PublishingDate = DateTime.Parse("1888-01-01"),
                EditorId = Guid.Parse("890D172F-2D04-49AD-AB05-A37525FB0AFE"),
                ImageUrl = "https://m.media-amazon.com/images/I/810-KS5SwaL._AC_UF1000,1000_QL80_.jpg",
                Description = "\"Under the Yoke\" is a seminal and deeply patriotic novel written by Bulgarian author Ivan Vazov. First published in 1888, it has become one of the most significant and influential works of Bulgarian literature, capturing the spirit of national identity and the struggle for liberation.\r\n\r\nSet during the late 19th century, \"Under the Yoke\" depicts the oppressive period of Ottoman rule in Bulgaria. The story revolves around the lives of Bulgarian revolutionaries and their clandestine efforts to resist the Turkish occupation. Vazov masterfully portrays the intricate dynamics of love, sacrifice, and the indomitable human spirit against the backdrop of a nation yearning for freedom.\r\n\r\nThe novel presents a vivid and realistic portrayal of the social, cultural, and political landscape of Bulgaria at the time. Vazov's prose breathes life into the characters, who navigate the complexities of their personal lives while dedicating themselves to the cause of national liberation.\r\n\r\n\"Under the Yoke\" is a compelling blend of historical fiction and social commentary. Through his characters, Vazov explores themes of patriotism, sacrifice, and the price of freedom. The novel captures the collective struggle and resilience of the Bulgarian people, inspiring generations to unite in their pursuit of independence.\r\n\r\nVazov's rich descriptions, poignant storytelling, and lyrical language evoke a sense of national pride and a deep connection to the Bulgarian landscape. The novel's enduring legacy lies in its ability to stir emotions and galvanize a sense of national consciousness, ultimately becoming a symbol of Bulgarian identity.\r\n\r\n\"Under the Yoke\" stands as a testament to Ivan Vazov's literary genius and his contribution to Bulgarian culture. It remains a cherished and beloved work, cherished for its portrayal of the indomitable spirit of a people yearning for liberation and a nation's unwavering determination to rise \"under the yoke.\"\r\n\r\nPrepare to be transported to a turbulent and transformative period of Bulgarian history as you delve into Ivan Vazov's \"Under the Yoke.\" This powerful and evocative novel will immerse you in the struggle for freedom, awakening a deep appreciation for the strength of the human spirit and the enduring quest for national identity."
            };
            books.Add(book);

            book = new Book()
            {
                IsActive = true,
                Title = "1984",
                NumberOfPages = 368,
                BookCoverId = 2,
                LanguageId = 1,
                ISBN = "9780452284234",
                PublishingDate = DateTime.Parse("1949-06-08", CultureInfo.InvariantCulture),
                EditorId = Guid.Parse("890D172F-2D04-49AD-AB05-A37525FB0AFE"),
                ImageUrl = "https://m.media-amazon.com/images/I/71kxa1-0mfL.jpg",
                Description = "\"1984\" is a dystopian masterpiece and prophetic novel written by English author George Orwell. Published in 1949, it presents a chilling vision of a totalitarian society ruled by a surveillance state known as Big Brother.\r\n\r\nSet in a future world where individualism and independent thought are suppressed, \"1984\" follows the life of Winston Smith, a low-ranking member of the ruling Party in the nation of Oceania. As Winston begins to question the Party's control and seeks personal freedom, he embarks on a dangerous journey of rebellion and self-discovery.\r\n\r\nOrwell's gripping narrative explores themes of government oppression, psychological manipulation, and the erosion of truth and individuality. The novel introduces the concept of \"Newspeak,\" a language designed to limit freedom of thought and control the minds of citizens, while \"Thought Police\" patrol for any signs of dissent or independent thinking.\r\n\r\n\"1984\" paints a bleak and haunting portrait of a surveillance state, where citizens are constantly monitored through telescreens and their every action is scrutinized. It delves into the psychological impact of living under constant fear and surveillance, and the devastating effects of propaganda and censorship on society.\r\n\r\nOrwell's writing is characterized by its precise and evocative prose, capturing the grim realities of the world he envisions. He creates an atmosphere of pervasive paranoia and hopelessness, illustrating the harrowing consequences of unchecked government power and the loss of personal freedoms.\r\n\r\n\"1984\" is not only a compelling work of fiction, but it also serves as a powerful warning against totalitarianism and the dangers of authoritarian regimes. Its themes of government control and manipulation of information have resonated with readers for decades, inspiring discussions about the nature of power and the importance of safeguarding individual liberties.\r\n\r\nPrepare to be captivated and disturbed as you delve into George Orwell's \"1984.\" This prophetic and thought-provoking novel will challenge your perceptions of freedom, truth, and the precarious balance between state control and individual autonomy. Its enduring relevance serves as a stark reminder of the importance of vigilance in safeguarding the principles of democracy and personal freedom."
            };
            books.Add(book);

            return books.ToArray();
        }
    }
}
