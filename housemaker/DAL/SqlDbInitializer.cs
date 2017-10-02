using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using housemaker.Models;

namespace housemaker.DAL
{
    public class SqlDbInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SqlDbContext>
    {

        protected override void Seed(SqlDbContext context)
        {

            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                Properties.Resources.testImage.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                var file = new MemoryFile(memoryStream, "image/png", "testImage.png");

                var photos = new List<CarouselItem>();

                var photo = new CarouselItem()
                {
                    IsActive = false,
                    IsShownCarousel = false,
                    File = file,
                    Photo = new byte[] { },
                    Url = "#",
                    Base64Image = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAWQAAAEYCAYAAABr+4yaAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAArPSURBVHhe7dxZiyRVAobhdEZxRdz3BfcNBVG8UAQv/E/ezg/zThAURbHBDXdRVLTc96WHLytP96mozLK1B/yYfh5IKjKzIjMiL944eSKqztrb2zu+AuAf96/NTwD+YYIMUEKQAUoIMkAJQQYoIcgAJQQZoIQgA5QQZIASggxQQpABSggyQAlBBighyAAlBBmghCADlBBkgBKCDFBCkAFKCDJACUEGKCHIACUEGaCEIAOUEGSAEoIMUEKQAUoIMkAJQQYoIcgAJQQZoIQgA5QQZIASggxQQpABSggyQAlBBighyAAlBBmghCADlBBkgBKCDFBCkAFKCDJACUEGKCHIACUEGaCEIAOUEGSAEoIMUEKQAUoIMkAJQQYoIcgAJQQZoIQgA5QQZIASggxQQpABSggyQAlBBighyAAlBBmghCADlBBkgBKCDFBCkAFKCDJACUEGKCHIACUEGaCEIAOUEGSAEoIMUEKQAUoIMkAJQQYoIcgAJQQZoIQgA5QQZIASggxQQpABSggyQAlBBighyAAlBBmghCADlBBkgBKCDFBCkAFKCDJACUEGKCHIACUEGaCEIAOUEGSAEoIMUEKQAUoIMkAJQQYoIcgAJQQZoIQgA5QQZIASggxQQpABSggyQAlBBighyAAlBBmghCADlBBkgBKCDFBCkAFKCDJACUEGKCHIACUEGaCEIAOUEGSAEoIMUEKQAUoIMkAJQQYoIcgAJQQZoIQgA5QQZIASggxQ4qy9vb3jm2U44ccff1y9/vrrq++++271888/rx+7+OKLV5dffvnqtttuW99f+uijj1avvfba5t5299xzz+r666/f3Dvp7bffXn3xxRerb775Zn3/3HPPXb/Xvffeu77/v5Jt/OSTT1bffvvt6rfffls/dir79VfXyef37rvvrvdpfH4XXHDB6uqrr965Dggyh3z22WerV1999UR8lhKiBx98cHPvpKzz8ccfb+5ttwxywpX1vvzyy80jByVijz766Obe6XnppZfWgdxl237lQJGw7rJtnexT3uuHH37YPHLQrs8PTFlwyHvvvbczxpGoJVRLCdFf9dZbb+2McSRqCfbpGiPwo+T5+b2++uqrI2Mc2z6L7NOuGEfWef/99zf34CRB5oCMjse0Qdx0002rJ598cvXwww+vpxGGxGopX+mHBx54YL3e8jaPjvMan3766ebe/sjxscceW98yMh7+LKSnYn6f7EdG6tme/Jz3a36v5Wj/lltuWa+TfTv77LM3jx5cJwelbfuUz2/ep0yDwJIgc0jmRxOP/LzzzjvXj11yySXr2/D7779vlvYlrvOo+qqrrtos7TYHL1HM1/jzzz9/fRvhzjbMwXz++edXTz/99InbfGDIwWR+7sUXX1w/nkjOI9YcZMbr5+d11123Xo4x37uU7Rhzv9m3XfuXbRgS7bFP+exuv/32zTP7I/+/842C/2+CzAEJzSOPPLKet83PISO6eSSYkd9sfi4BTQznMG4bEeaE4XDRRRdtlvbdfPPN69FotmHejnGAGObpgky1DNmGcUIwI/cENbdYxnQe7Z6u77//frO0P/89W77v3t7eZgn2CTJHSkgT1Vw9MUbAifHySoF5BJpR5jwvnOWsv5xrnddJQDN/+8wzz6zfLz9zYmw5isxIcx7R5rWzjW+++eaBqZZbb711PTKNcZDJLZEfjw9zGC+99NLN0mp1xRVXbJZW69ce259R8DwSnr85zAeZc845Z7N00jza//rrrzdLsE+Q+Usy6stc6tI8f7xLTpDNUwzzFEcClymMMWWQnxl1v/DCC4fmqzPynUefOUE2T3/k0rJ5rvooy5N911xzzWZpP+Tzvmb7c7B45ZVXDhyclqP2YY7vsO0xGASZIy1HcRnVvvzyy4euEsjX/sQmPzNHmxNZGY0u473rqoVdV3UkzBn9LmVKY8g2jfWzDfNc7VES43l7MjpehjzfBJbTM0MOCnfffffmHpw+QeZImR5IWBPYEabELyGbpxMyHfD444+vnnjiifWIcUwLJGgZsQ7zV/qlcUXH/F6R6YJ5iiASzvl1h3mq4ijLGCeuyz9Cyf49++yzB0bQsxwInnvuuUPbBn+XIHOkMT+ayOWKgXECLFH+sz8CGS677LLN0sGrGOaTaQni+Oq/fK/4/PPPN0snza8b+f0LL7xwc2+3bSPjcTXEbL6eOCPvcalcLmEbJwjzObzxxhvr5aV5X4dd+w8hyByQ6YFcWpaTaseOHds8etI8dzvikhFi1hmXpC3tmo6YX2tbnObnt1lOm+R9tk1vzHKicI5xvgE89NBDW0fV88g4vzemM3KQmueN8zmMUfJ8tcivv/66WTppDvKpHDw4swgyB+SyrUwRJBzLk2n5Cj9fyTAimvDk8fHc8hK3eZ05snME51AN81UYy2Dnioz5+SHvtSvK8wm8vN4dd9xx5P/K2HUg2WbEdz5pt9y+5dTGcoQPgswB46t4JJLj0rPc8s+GZuO62owc52C+8847J+KTOM5/uTZfSracypjfK6PzOYjzpWV57Xm6JKPXOfR5bnkwyUFiHhknxvOJwW3muH744YcnDjR57WX0x77Mc9/Z/rFPWSdTIEO2d9uonDObfy7EITmRtW30OcsJtfvvv39zbz+8H3zwwebedglc5l/nEGWaYx5Bb5ODxPzHIfP25TVzMjGRzuVow3KdTMFsG4Vvk3niyCj8VObJE+HMQQ+J8K4TgcOpHBA48xghc0i+xs+jw6WcBFteWpY51V2Xh0VG0HfdddehUWGiftRccZ6bw7+cqshVFZHR+vwHI/PUReaaTzXGs3wOR+1TZPuWl77l/lH7lNcUY7b591NPPfWfzTKsnXfeeevA5f9V/PLLLyf+b0VGnYnefffdt/Wv0K699trV8ePHV3/88ceJACbsmabIP+SZpx2GvM6NN964+umnn9bvM+ZiE7Qrr7xyfWXDiHhGwfPX/ozS5wNDfj//t3i8RubD8575S7xT+cOVYUQ+sk/Zh2xbpiCyb5Hty3PbDjLZp+xz1lnu0w033HDkvDVnNlMWACVMWQCUEGSAEoIMUEKQAUoIMkAJQQYoIcgAJQQZoIQgA5QQZIASggxQQpABSggyQAlBBighyAAlBBmghCADlBBkgBKCDFBCkAFKCDJACUEGKCHIACUEGaCEIAOUEGSAEoIMUEKQAUoIMkAJQQYoIcgAJQQZoIQgA5QQZIASggxQQpABSggyQAlBBighyAAlBBmghCADlBBkgBKCDFBCkAFKCDJACUEGKCHIACUEGaCEIAOUEGSAEoIMUEKQAUoIMkAJQQYoIcgAJQQZoIQgA5QQZIASggxQQpABSggyQAlBBighyAAlBBmghCADlBBkgBKCDFBCkAFKCDJACUEGKCHIACUEGaCEIAOUEGSAEoIMUEKQAUoIMkAJQQYoIcgAJQQZoIQgA5QQZIASggxQQpABSggyQAlBBighyAAlBBmghCADlBBkgBKCDFBCkAFKCDJACUEGKCHIACUEGaCEIAOUEGSAEoIMUEKQAUoIMkAJQQYoIcgAJQQZoIQgA5QQZIASggxQQpABSggyQAlBBighyAAlBBmghCADlBBkgBKCDFBCkAFKCDJACUEGKCHIACUEGaCEIAOUEGSAEoIMUEKQAUoIMkAJQQYoIcgAJQQZoIQgA5QQZIASggxQYbX6L9G6uFpdztyjAAAAAElFTkSuQmCC",
                    Headline = "Test image",
                    Description = $"Test description {DateTime.Now:yyyy-MM-dd  HH:mm:ss}",
                    Text = "",
                    ButtonText = "Test action",
                    ButtonUrl = "#",
                };

                photos.Add(photo);
                photos.ForEach(s => context.Photos.Add(s));
                context.SaveChanges();

            }
        }

    }
}