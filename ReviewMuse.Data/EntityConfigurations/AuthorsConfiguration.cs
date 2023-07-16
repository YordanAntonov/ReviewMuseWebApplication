namespace ReviewMuse.Data.EntityConfigurations
{
    using System.Globalization;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using ReviewMuse.Data.Models;

    public class AuthorsConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasData(this.GenerateAuthors());
        }

        private Author[] GenerateAuthors()
        {
            ICollection<Author> authors = new HashSet<Author>();

            Author author;

            author = new Author()
            {
                IsActive = true,
                FullName = "Howard Philips Lovecraft",
                Pseudonim = "H.P Lovecraft",
                DateOfBirth = DateTime.Parse("1890-08-20", CultureInfo.InvariantCulture),
                DateOfDeath = DateTime.Parse("1937-03-15", CultureInfo.InvariantCulture),
                City = "Providance, Rhode Island",
                Country = "United States of America",
                Website = "https://www.hplovecraft.com/",
                ImageUrl = "https://en.wikipedia.org/wiki/H._P._Lovecraft#/media/File:H._P._Lovecraft,_June_1934.jpg",
                Description = "Howard Phillips Lovecraft (1890-1937) was an American writer known for his influential contributions to the horror fiction genre. Lovecraft's life was marked by personal struggles, but he left a lasting legacy with his unique and imaginative storytelling. Lovecraft was born in Providence, Rhode Island, and spent most of his life in New England. He was a reclusive individual, largely confined to his home due to health issues and personal anxieties. As a result, he relied heavily on his vivid imagination and extensive reading to create his eerie and otherworldly tales. Lovecraft's writing style was characterized by his ability to evoke a sense of cosmic dread, exploring themes of existential horror, the insignificance of humanity, and the existence of ancient and malevolent beings beyond human comprehension. His stories often featured dark and foreboding settings, intricate mythologies, and a sense of intellectual terror. While Lovecraft's work received little recognition during his lifetime, his stories gained popularity posthumously and had a profound influence on subsequent generations of writers, filmmakers, and artists. The concept of a shared universe and mythos, known as the \"Cthulhu Mythos,\" emerged from Lovecraft's writings, creating a vast and interconnected mythology that expanded beyond his original works.\r\n\r\nDespite his literary contributions, Lovecraft faced financial hardships throughout his life and struggled to gain widespread acclaim. He often relied on ghostwriting and amateur press contributions for income. It wasn't until years after his death that Lovecraft's work began to be celebrated as a significant contribution to the horror genre.\r\n\r\nToday, Lovecraft is regarded as one of the most influential horror writers of the 20th century. His unique blend of cosmic horror, imaginative world-building, and atmospheric storytelling continues to captivate readers and inspire new generations of writers to explore the depths of the unknown and the terrifying aspects of human existence."
            };
            authors.Add(author);

            author = new Author()
            {
                IsActive = true,
                FullName = "Terence David John Pratchett",
                Pseudonim = "Terry Pratchett",
                DateOfBirth = DateTime.Parse("1948-04-28", CultureInfo.InvariantCulture),
                DateOfDeath = DateTime.Parse("2015-03-12", CultureInfo.InvariantCulture),
                City = "Buckinghamshire",
                Country = "England",
                Website = "https://www.terrypratchettbooks.com/",
                ImageUrl = "https://en.wikipedia.org/wiki/Terry_Pratchett#/media/File:10.12.12TerryPratchettByLuigiNovi1.jpg",
                Description = "Sir Terry Pratchett (1948-2015) was a highly acclaimed British author best known for his humorous and insightful fantasy novels set in the Discworld universe. Pratchett's life was filled with creativity, wit, and a passion for storytelling.\r\n\r\nBorn in Beaconsfield, England, Pratchett displayed an early interest in writing and fantasy. He published his first story at the age of 13 and went on to become a successful journalist and press officer before fully committing to his career as a novelist.\r\n\r\nPratchett's most famous works are set in the Discworld, a flat, disc-shaped world balanced on the backs of four giant elephants, which in turn stand atop a massive turtle swimming through space. This fantastical setting allowed Pratchett to explore a vast array of themes and satirize various aspects of society, including politics, religion, and human nature.\r\n\r\nHis Discworld novels, numbering over 40, combine elements of fantasy, humor, and social commentary, captivating readers with their unique blend of wit and imagination. Pratchett's writing was known for its clever wordplay, memorable characters, and insightful observations on the human condition.\r\n\r\nIn addition to his literary achievements, Pratchett was also an advocate for Alzheimer's research and awareness. Diagnosed with early-onset Alzheimer's disease in 2007, he used his platform to raise awareness about the condition and the importance of funding research.\r\n\r\nPratchett received numerous accolades for his work, including the prestigious Carnegie Medal and the British Fantasy Society's Lifetime Achievement Award. He was knighted by Queen Elizabeth II in 2009 for his services to literature.\r\n\r\nTerry Pratchett's legacy continues to shine brightly even after his passing. His books have sold millions of copies worldwide and have been translated into numerous languages. His unique blend of fantasy and satire, coupled with his unwavering commitment to storytelling, has earned him a place among the most beloved and influential authors of the fantasy genre."
            };
            authors.Add(author);

            author = new Author()
            {
                IsActive = true,
                FullName = "Edgar Allan Poe",
                Pseudonim = "Egar Poe",
                DateOfBirth = DateTime.Parse("1809-01-19", CultureInfo.InvariantCulture),
                DateOfDeath = DateTime.Parse("1849-10-07", CultureInfo.InvariantCulture),
                City = "Boston, Massachusetts",
                Country = "United States of America",
                Website = "https://poestories.com/",
                ImageUrl = "https://en.wikipedia.org/wiki/Edgar_Allan_Poe#/media/File:Edgar_Allan_Poe,_circa_1849,_restored,_squared_off.jpg",
                Description = "Edgar Allan Poe (1809-1849) was an American writer and poet known for his macabre and suspenseful tales. Poe's life was filled with tragedy and struggles, but he left an indelible mark on the literary world with his unique style and exploration of the darker aspects of human existence.\r\n\r\nBorn in Boston, Massachusetts, Poe had a tumultuous upbringing. He lost both of his parents at a young age and was subsequently taken in by foster parents. Despite his intelligence and talents, Poe faced financial difficulties throughout his life, which often led to a nomadic existence.\r\n\r\nPoe's writing career began with poetry, and his early works gained some recognition. However, it was his short stories that truly cemented his place in literary history. His stories, such as \"The Tell-Tale Heart,\" \"The Fall of the House of Usher,\" and \"The Masque of the Red Death,\" are renowned for their eerie atmosphere, psychological depth, and exploration of themes such as guilt, madness, and death.\r\n\r\nPoe's writing style was characterized by his meticulous attention to detail, use of symbolism, and mastery of the macabre. He is considered one of the pioneers of the detective fiction genre with his iconic detective character, C. Auguste Dupin, inspiring later detectives such as Sherlock Holmes.\r\n\r\nDespite his contributions to literature, Poe struggled to achieve financial success during his lifetime. He faced personal hardships, including the death of his wife, Virginia, which had a profound impact on his emotional well-being and creative output.\r\n\r\nPoe's life ended tragically when he was found delirious on the streets of Baltimore and died shortly after. The exact circumstances surrounding his death remain a mystery to this day.\r\n\r\nAlthough Poe's life was marked by tragedy and misfortune, his literary works continue to captivate readers and inspire generations of writers. His exploration of the human psyche and the darker side of human nature have made him an enduring figure in the realms of horror, mystery, and poetry. Edgar Allan Poe's legacy as a master of the macabre and a pioneer of psychological storytelling remains unparalleled."
            };
            authors.Add(author);

            author = new Author()
            {
                IsActive = true,
                FullName = "Ernest Miller Hemingway",
                Pseudonim = "Ernest Hemingway",
                DateOfBirth = DateTime.Parse("1899-07-21", CultureInfo.InvariantCulture),
                DateOfDeath = DateTime.Parse("1961-07-02", CultureInfo.InvariantCulture),
                City = "Oak Park, Illinois",
                Country = "United States of America",
                Website = "https://www.ernesthemingway.org/",
                ImageUrl = "https://en.wikipedia.org/wiki/Ernest_Hemingway#/media/File:ErnestHemingway.jpg",
                Description = "Ernest Hemingway (1899-1961) was an iconic American author known for his concise and powerful writing style, as well as his adventurous and often tumultuous life. Hemingway's life was filled with travel, war experiences, and a relentless pursuit of literary excellence.\r\n\r\nBorn in Oak Park, Illinois, Hemingway's early years were influenced by his love for outdoor activities and his time spent in nature. This love for adventure and his experiences as an ambulance driver during World War I shaped his writing and laid the foundation for his later works.\r\n\r\nHemingway's writing style was characterized by its simplicity, directness, and economy of language. He believed in the power of understatement and omission, and his prose often conveyed deep emotions and themes through concise and straightforward storytelling.\r\n\r\nHis works, including \"The Old Man and the Sea,\" \"For Whom the Bell Tolls,\" and \"A Farewell to Arms,\" tackled themes of courage, heroism, masculinity, and the futility of war. Hemingway's writing reflected his own experiences and offered a unique perspective on human nature and the human condition.\r\n\r\nThroughout his life, Hemingway traveled extensively, living in various parts of the world, including Paris, Key West, and Cuba. These experiences enriched his writing and added to the depth of his storytelling.\r\n\r\nHemingway's personal life was marked by numerous relationships and marriages, as well as his love for outdoor pursuits such as hunting, fishing, and bullfighting. His larger-than-life persona and adventurous spirit added to his mystique and made him a celebrated figure in literary circles.\r\n\r\nDespite his successes, Hemingway battled inner demons, including struggles with depression and alcoholism. Tragically, he took his own life in 1961.\r\n\r\nErnest Hemingway's impact on literature is profound. His unique writing style and exploration of themes continue to inspire and influence writers today. He remains one of the most influential and celebrated authors of the 20th century, leaving behind a legacy of exceptional storytelling and a reputation as a literary giant."
            };
            authors.Add(author);

            author = new Author()
            {
                IsActive = true,
                FullName = "Ivan Minchov Vazov",
                Pseudonim = "Ivan Vazov",
                DateOfBirth = DateTime.Parse("1850-07-09", CultureInfo.InvariantCulture),
                DateOfDeath = DateTime.Parse("1921-09-22", CultureInfo.InvariantCulture),
                City = "Sopot",
                Country = "Bulgaria",
                ImageUrl = "https://en.wikipedia.org/wiki/Ivan_Vazov#/media/File:Ivan_Vazov_Coloured_Improved.jpg",
                Description = "Ivan Vazov (1850-1921) was a prominent Bulgarian writer, poet, and public figure, often hailed as the \"Patriarch of Bulgarian literature.\" His life and work played a significant role in shaping Bulgarian cultural and national identity during a crucial period in the country's history.\r\n\r\nBorn in Sopot, Bulgaria, Vazov demonstrated literary talent from an early age. He studied in Stara Zagora and later pursued his education in Odessa, Ukraine. It was during his time in Odessa that he became actively involved in the Bulgarian revolutionary movement against Ottoman rule.\r\n\r\nVazov's literary career spanned various genres, including poetry, novels, and plays. His poetic works, such as \"Epics and Songs,\" reflected the spirit of Bulgarian nationalism and celebrated the struggles and triumphs of the Bulgarian people.\r\n\r\nHowever, Vazov's most celebrated work is his novel \"Under the Yoke\" (Pod Igoto). Published in 1888, it depicts the Bulgarian struggle for liberation from Ottoman rule and became a symbol of national awakening. The novel not only portrayed historical events but also explored the complex social and political realities of the time.\r\n\r\nVazov's writing style was marked by rich imagery, emotional depth, and a love for his homeland. His works often depicted the beauty of Bulgarian nature and celebrated the courage and resilience of the Bulgarian people.\r\n\r\nBeyond his literary contributions, Vazov played a significant role in the cultural and social development of Bulgaria. He was actively involved in public affairs and advocated for education, the promotion of Bulgarian language and culture, and the strengthening of national unity.\r\n\r\nVazov's impact on Bulgarian literature and society cannot be overstated. His works continue to be cherished and widely read in Bulgaria, serving as a source of inspiration and a testament to the enduring spirit of the Bulgarian people. Ivan Vazov's legacy as a patriot, writer, and advocate for Bulgarian culture remains an integral part of the nation's literary and cultural heritage."
            };
            authors.Add(author);

            author = new Author()
            {
                IsActive = true,
                FullName = "Eric Arthur Blair",
                Pseudonim = "George Orwell",
                DateOfBirth = DateTime.Parse("1903-06-25", CultureInfo.InvariantCulture),
                DateOfDeath = DateTime.Parse("1950-01-21", CultureInfo.InvariantCulture),
                City = "Motihari",
                Country = "Bengal, British India",
                ImageUrl = "https://en.wikipedia.org/wiki/George_Orwell#/media/File:George_Orwell_press_photo.jpg",
                Description = "George Orwell, born Eric Arthur Blair (1903-1950), was an English writer and journalist known for his keen observations, political insight, and powerful works of fiction. Orwell's life was shaped by his experiences in the early 20th century, including his time serving in the British Imperial Police in Burma and his participation in the Spanish Civil War.\r\n\r\nBorn in Motihari, India (now part of modern-day Bihar, India), Orwell grew up in England and attended prestigious schools such as Eton College. After completing his education, he opted for a less conventional path, joining the Indian Imperial Police in Burma. This experience exposed him to the oppressive nature of imperialism, which greatly influenced his later writings.\r\n\r\nOrwell's literary career took off with the publication of his first major work, \"Down and Out in Paris and London,\" which recounted his experiences living among the destitute. However, it was his dystopian novels, \"Animal Farm\" (1945) and \"Nineteen Eighty-Four\" (1949), that brought him enduring fame and critical acclaim. These novels highlighted totalitarianism, surveillance, and the abuse of power, serving as chilling warnings about the dangers of authoritarian regimes.\r\n\r\nThroughout his life, Orwell was deeply committed to the pursuit of truth and social justice. His experiences in the Spanish Civil War, fighting against fascism, solidified his anti-totalitarian stance. He used his writings, essays, and journalistic work to criticize totalitarianism, advocate for democratic socialism, and shed light on social inequality.\r\n\r\nOrwell's writing style was characterized by its clarity, simplicity, and directness. He believed that language should be transparent and truthful, and his works reflected his commitment to honest expression. Concepts such as \"Big Brother\" and \"Newspeak\" from \"Nineteen Eighty-Four\" have become enduring symbols in popular culture, reflecting his impact on literature and society.\r\n\r\nGeorge Orwell's contributions to literature and political thought continue to resonate today. His works remain relevant in discussions about government surveillance, censorship, and the manipulation of truth. Orwell's life and writings exemplify a commitment to truth-telling and the defense of democratic values, making him one of the most influential and respected writers of the 20th century."
            };
            authors.Add(author);

            author = new Author()
            {
                IsActive = true,
                FullName = "Stephen Edwin King",
                Pseudonim = "Stephen King",
                DateOfBirth = DateTime.Parse("1947-09-21"),
                City = "Portland, Maine",
                Country = "United States of America",
                Website = "https://stephenking.com/",
                ImageUrl = "https://en.wikipedia.org/wiki/Stephen_King#/media/File:Stephen_King,_Comicon.jpg",
                Description = "Stephen King, born on September 21, 1947, in Portland, Maine, is a prolific and internationally acclaimed American author known for his contributions to the horror and suspense genres. King's life is characterized by his extraordinary storytelling abilities, his deep understanding of human fears, and his remarkable work ethic.\r\n\r\nKing developed a passion for writing at an early age and began submitting stories to magazines as a teenager. However, it was his debut novel, \"Carrie\" (1974), that catapulted him to literary stardom. Since then, he has written numerous bestselling novels, short stories, and novellas, establishing himself as one of the most influential and successful authors of his generation.\r\n\r\nKing's writing style is characterized by his vivid descriptions, realistic characters, and an ability to delve into the darkest corners of the human psyche. He masterfully blends elements of horror, suspense, and the supernatural, creating stories that resonate with readers around the world.\r\n\r\nDespite his fame and success, King has remained down-to-earth and relatable. He often draws inspiration from his own experiences, childhood memories, and the small towns of Maine, which frequently serve as settings for his stories. This personal touch adds an authenticity and depth to his narratives.\r\n\r\nThroughout his career, King has received numerous accolades and awards for his contributions to literature. His notable works include \"The Shining,\" \"It,\" \"Misery,\" \"The Stand,\" and \"Pet Sematary,\" among many others. Many of his books have been adapted into successful films and television series, solidifying his impact on popular culture.\r\n\r\nBeyond his horror novels, King has also explored other genres, such as fantasy, science fiction, and crime fiction, under the pseudonym Richard Bachman. He has proven his versatility as a writer, consistently captivating readers with his storytelling prowess.\r\n\r\nStephen King's life and work have inspired countless authors and filmmakers, and his influence on the horror genre is unparalleled. His ability to tap into universal fears and explore the human condition with authenticity and depth has made him a literary icon, and his legacy continues to thrive as he continues to captivate audiences with his unique brand of storytelling."
            };
            authors.Add(author);

            author = new Author()
            {
                IsActive = true,
                FullName = "Agatha Mary Clarissa Miller",
                Pseudonim = "Agatha Christie",
                DateOfBirth = DateTime.Parse("1890-09-15", CultureInfo.InvariantCulture),
                DateOfDeath = DateTime.Parse("1976-01-12", CultureInfo.InvariantCulture),
                City = "Torquay",
                Country = "England",
                Website = "https://www.agathachristie.com/",
                ImageUrl = "https://nl.wikipedia.org/wiki/Agatha_Christie#/media/Bestand:Agatha_Christie.png",
                Description = "Agatha Christie (1890-1976) was a renowned British author and one of the most influential figures in the mystery and detective fiction genre. With her captivating storytelling and intriguing plot twists, Christie became a literary icon, often referred to as the \"Queen of Crime.\"\r\n\r\nBorn Agatha Mary Clarissa Miller in Torquay, England, Christie's childhood was marked by a love for storytelling and a fascination with puzzles and mysteries. Her writing career began in her thirties when her first detective novel, \"The Mysterious Affair at Styles\" (1920), introduced the world to her beloved detective character, Hercule Poirot.\r\n\r\nChristie's novels and short stories spanned a wide range of settings and characters, but they all shared her signature style of intricate plotting and unexpected reveals. Her works, including \"Murder on the Orient Express,\" \"And Then There Were None,\" and \"Death on the Nile,\" continue to captivate readers with their suspenseful narratives and engaging characters.\r\n\r\nThroughout her life, Christie's creativity and imagination seemed boundless. She created not only the iconic Hercule Poirot but also another beloved detective, Miss Marple, as well as a multitude of memorable secondary characters. Her keen observations of human nature and her ability to create intricate puzzles contributed to her enduring popularity.\r\n\r\nBeyond her immense literary success, Christie led a fascinating personal life. She traveled extensively, drawing inspiration from her journeys to far-flung destinations and weaving them into her stories. Her experiences as a nurse during World War I also influenced her writing, bringing realism and depth to her portrayal of crime and its impact on society.\r\n\r\nAgatha Christie's works have had an immeasurable impact on the mystery genre, and her books have sold millions of copies worldwide, making her one of the best-selling authors of all time. Her literary legacy lives on, with adaptations of her stories continuing to thrill audiences through television, film, and stage productions.\r\n\r\nAgatha Christie's enduring appeal lies in her ability to create compelling mysteries, fascinating characters, and intricate plot twists. Her contributions to the world of crime fiction have secured her a permanent place among the greatest authors of all time."
            };
            authors.Add(author);

            return authors.ToArray();
        }
    }
}
