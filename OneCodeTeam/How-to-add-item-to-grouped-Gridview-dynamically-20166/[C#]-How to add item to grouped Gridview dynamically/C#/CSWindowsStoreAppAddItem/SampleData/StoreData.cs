/****************************** Module Header ******************************\
 * Module Name:  StoreData.cs
 * Project:      CSWindowsStoreAppAddItem
 * Copyright (c) Microsoft Corporation.
 * 
 * This is the sample data which bind to the GridView
 *  
 * 
 * This source is subject to the Microsoft Public License.
 * See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
 * All other rights reserved.
 * 
 * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 * EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

namespace CSWindowsStoreAppAddItem.SampleData
{
    using System;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// The store data used to initially populate the grid.
    /// </summary>
    public class StoreData
    {
        public static readonly Uri BaseUri = new Uri("ms-appx:///");

        private readonly ItemCollection _collection = new ItemCollection();

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreData"/> class.
        /// </summary>
        public StoreData()
        {        
            string longLoremIpsum = string.Format(
                CultureInfo.InvariantCulture,
                "{0}\n\n{0}\n\n{0}\n\n{0}",
                "Curabitur class aliquam vestibulum nam curae maecenas sed integer cras phasellus suspendisse quisque donec dis praesent accumsan bibendum pellentesque condimentum adipiscing etiam consequat vivamus dictumst aliquam duis convallis scelerisque est parturient ullamcorper aliquet fusce suspendisse nunc hac eleifend amet blandit facilisi condimentum commodo scelerisque faucibus aenean ullamcorper ante mauris dignissim consectetuer nullam lorem vestibulum habitant conubia elementum pellentesque morbi facilisis arcu sollicitudin diam cubilia aptent vestibulum auctor eget dapibus pellentesque inceptos leo egestas interdum nulla consectetuer suspendisse adipiscing pellentesque proin lobortis sollicitudin augue elit mus congue fermentum parturient fringilla euismod feugiat");

            Item item = new Item
                            {
                                Title = "Banana Blast Frozen Yogurt",
                                Subtitle =
                                    "Maecenas class nam praesent cras aenean mauris aliquam nullam aptent accumsan duis nunc curae donec integer auctor sed congue amet",
                                    Link = "http://www.adatum.com/",
                                    Category = "Low-fat frozen yogurt",
                                    Description = "Curabitur class aliquam vestibulum nam curae maecenas sed integer cras phasellus suspendisse quisque donec dis praesent accumsan bibendum pellentesque condimentum adipiscing etiam consequat vivamus dictumst aliquam duis convallis scelerisque est parturient ullamcorper aliquet fusce suspendisse nunc hac eleifend amet blandit facilisi condimentum commodo scelerisque faucibus aenean ullamcorper ante mauris dignissim consectetuer nullam lorem vestibulum habitant conubia elementum pellentesque morbi facilisis arcu sollicitudin diam cubilia aptent vestibulum auctor eget dapibus pellentesque inceptos leo egestas interdum nulla consectetuer suspendisse adipiscing pellentesque proin lobortis sollicitudin augue elit mus congue fermentum parturient fringilla euismod feugiat",
                                    Content = longLoremIpsum
                            };
            item.SetImage(BaseUri, "SampleData/Images/60Banana.png");
            Collection.Add(item);

            item = new Item
                       {
                           Title = "Lavish Lemon Ice",
                           Subtitle =
                               "Quisque vivamus bibendum cursus dictum dictumst dis aliquam aliquet etiam lectus eleifend fusce libero ante facilisi ligula est",
                               Link = "http://www.adventure-works.com/",
                               Category = "Sorbet",
                               Description = "Enim cursus nascetur dictum habitasse hendrerit nec gravida vestibulum pellentesque vestibulum adipiscing iaculis erat consectetuer pellentesque parturient lacinia himenaeos pharetra condimentum non sollicitudin eros dolor vestibulum per lectus pellentesque nibh imperdiet laoreet consectetuer placerat libero malesuada pellentesque fames penatibus ligula scelerisque litora nisi luctus vestibulum nisl ullamcorper sed sem natoque suspendisse felis sit condimentum pulvinar nunc posuere magnis vel scelerisque sagittis porttitor potenti tincidunt mattis ipsum adipiscing sollicitudin parturient mauris nam senectus ullamcorper mollis tristique sociosqu suspendisse ultricies montes sed condimentum dis nostra suscipit justo ornare pretium odio pellentesque lacus lorem torquent orci",
                               Content = longLoremIpsum
                       };
            item.SetImage(BaseUri, "SampleData/Images/60Lemon.png");
            Collection.Add(item);

            item = new Item
                       {
                           Title = "Marvelous Mint",
                           Subtitle =
                               "Litora luctus magnis arcu lorem morbi blandit faucibus mattis commodo hac habitant inceptos conubia cubilia nulla mauris diam proin augue eget dolor mollis interdum lobortis",
                           Link = "http://www.adventure-works.com/",
                           Category = "Gelato",
                           Description =
                               "Vestibulum vestibulum magna scelerisque ultrices consectetuer vehicula rhoncus pellentesque massa adipiscing platea primis sodales parturient metus sollicitudin morbi vestibulum pellentesque consectetuer pellentesque volutpat rutrum sollicitudin sapien pellentesque vestibulum venenatis consectetuer viverra est aliquam semper hac maecenas integer adipiscing sociis vulputate ullamcorper curabitur pellentesque parturient praesent neque sollicitudin pellentesque vestibulum suspendisse consectetuer leo quisque phasellus pede vestibulum quam pellentesque sollicitudin quis mus adipiscing parturient pellentesque vestibulum",
                           Content = longLoremIpsum
                       };
            item.SetImage(BaseUri, "SampleData/Images/60Mint.png");
            Collection.Add(item);

            item = new Item
                       {
                           Title = "Creamy Orange",
                           Subtitle =
                               "Leo mus nec nascetur dapibus non fames per felis ipsum pharetra egestas montes elit nostra placerat euismod enim justo ornare feugiat platea pulvinar sed sagittis",
                           Link = "http://www.alpineskihouse.com/",
                           Category = "Sorbet",
                           Description =
                               "Consequat condimentum consectetuer vivamus urna vestibulum netus pellentesque cras nec taciti non scelerisque adipiscing parturient tellus sollicitudin per vestibulum pellentesque aliquam convallis ullamcorper nulla porta aliquet accumsan suspendisse duis bibendum nunc condimentum consectetuer pellentesque scelerisque tempor sed dictumst eleifend amet vestibulum sem tempus facilisi ullamcorper adipiscing tortor ante purus parturient sit dignissim vel nam turpis sed sollicitudin elementum arcu vestibulum risus blandit suspendisse faucibus pellentesque commodo dis condimentum consectetuer varius aenean conubia cubilia facilisis velit mauris nullam aptent dapibus habitant",
                           Content = longLoremIpsum
                       };
            item.SetImage(BaseUri, "SampleData/Images/60Orange.png");
            Collection.Add(item);

            item = new Item
                       {
                           Title = "Succulent Strawberry",
                           Subtitle =
                               "Senectus sem lacus erat sociosqu eros suscipit primis nibh nisi nisl gravida torquent",
                           Link = "http://www.baldwinmuseumofscience.com/",
                           Category = "Sorbet",
                           Description =
                               "Est auctor inceptos congue interdum egestas scelerisque pellentesque fermentum ullamcorper cursus dictum lectus suspendisse condimentum libero vitae vestibulum lobortis ligula fringilla euismod class scelerisque feugiat habitasse diam litora adipiscing sollicitudin parturient hendrerit curae himenaeos imperdiet ullamcorper suspendisse nascetur hac gravida pharetra eget donec leo mus nec non malesuada vestibulum pellentesque elit penatibus vestibulum per condimentum porttitor sed adipiscing scelerisque ullamcorper etiam iaculis enim tincidunt erat parturient sem vestibulum eros",
                           Content = longLoremIpsum
                       };
            item.SetImage(BaseUri, "SampleData/Images/60Strawberry.png");
            Collection.Add(item);

            item = new Item
                       {
                           Title = "Very Vanilla",
                           Subtitle =
                               "Ultrices rutrum sapien vehicula semper lorem volutpat sociis sit maecenas praesent taciti magna nunc odio orci vel tellus nam sed accumsan iaculis dis est",
                           Link = "http://www.blueyonderairlines.com/",
                           Category = "Ice Cream",
                           Description =
                               "Consectetuer lacinia vestibulum tristique sit adipiscing laoreet fusce nibh suspendisse natoque placerat pulvinar ultricies condimentum scelerisque nisi ullamcorper nisl parturient vel suspendisse nam venenatis nunc lorem sed dis sagittis pellentesque luctus sollicitudin morbi posuere vestibulum potenti magnis pellentesque vulputate mattis mauris mollis consectetuer pellentesque pretium montes vestibulum condimentum nulla adipiscing sollicitudin scelerisque ullamcorper pellentesque odio orci rhoncus pede sodales suspendisse parturient viverra curabitur proin aliquam integer augue quam condimentum quisque senectus quis urna scelerisque nostra phasellus ullamcorper cras duis suspendisse sociosqu dolor vestibulum condimentum consectetuer vivamus est fames felis suscipit hac",
                           Content = longLoremIpsum
                       };
            item.SetImage(BaseUri, "SampleData/Images/60Vanilla.png");
            Collection.Add(item);

            item = new Item
                       {
                           Title = "Creamy Caramel Frozen Yogurt",
                           Subtitle =
                               "Maecenas class nam praesent cras aenean mauris aliquam nullam aptent accumsan duis nunc curae donec integer auctor sed congue amet",
                           Link = "http://www.adatum.com/",
                           Category = "Low-fat frozen yogurt",
                           Description =
                               "Curabitur class aliquam vestibulum nam curae maecenas sed integer cras phasellus suspendisse quisque donec dis praesent accumsan bibendum pellentesque condimentum adipiscing etiam consequat vivamus dictumst aliquam duis convallis scelerisque est parturient ullamcorper aliquet fusce suspendisse nunc hac eleifend amet blandit facilisi condimentum commodo scelerisque faucibus aenean ullamcorper ante mauris dignissim consectetuer nullam lorem vestibulum habitant conubia elementum pellentesque morbi facilisis arcu sollicitudin diam cubilia aptent vestibulum auctor eget dapibus pellentesque inceptos leo egestas interdum nulla consectetuer suspendisse adipiscing pellentesque proin lobortis sollicitudin augue elit mus congue fermentum parturient fringilla euismod feugiat",
                           Content = longLoremIpsum
                       };
            item.SetImage(BaseUri, "SampleData/Images/60SauceCaramel.png");
            Collection.Add(item);

            item = new Item
                       {
                           Title = "Chocolate Lovers Frozen Yougurt",
                           Subtitle =
                               "Quisque vivamus bibendum cursus dictum dictumst dis aliquam aliquet etiam lectus eleifend fusce libero ante facilisi ligula est",
                           Link = "http://www.adventure-works.com/",
                           Category = "Low-fat frozen yogurt",
                           Description =
                               "Enim cursus nascetur dictum habitasse hendrerit nec gravida vestibulum pellentesque vestibulum adipiscing iaculis erat consectetuer pellentesque parturient lacinia himenaeos pharetra condimentum non sollicitudin eros dolor vestibulum per lectus pellentesque nibh imperdiet laoreet consectetuer placerat libero malesuada pellentesque fames penatibus ligula scelerisque litora nisi luctus vestibulum nisl ullamcorper sed sem natoque suspendisse felis sit condimentum pulvinar nunc posuere magnis vel scelerisque sagittis porttitor potenti tincidunt mattis ipsum adipiscing sollicitudin parturient mauris nam senectus ullamcorper mollis tristique sociosqu suspendisse ultricies montes sed condimentum dis nostra suscipit justo ornare pretium odio pellentesque lacus lorem torquent orci",
                           Content = longLoremIpsum
                       };
            item.SetImage(BaseUri, "SampleData/Images/60SauceChocolate.png");
            Collection.Add(item);

            item = new Item
                       {
                           Title = "Roma Strawberry",
                           Subtitle =
                               "Litora luctus magnis arcu lorem morbi blandit faucibus mattis commodo hac habitant inceptos conubia cubilia nulla mauris diam proin augue eget dolor mollis interdum lobortis",
                           Link = "http://www.adventure-works.com/",
                           Category = "Gelato",
                           Description =
                               "Vestibulum vestibulum magna scelerisque ultrices consectetuer vehicula rhoncus pellentesque massa adipiscing platea primis sodales parturient metus sollicitudin morbi vestibulum pellentesque consectetuer pellentesque volutpat rutrum sollicitudin sapien pellentesque vestibulum venenatis consectetuer viverra est aliquam semper hac maecenas integer adipiscing sociis vulputate ullamcorper curabitur pellentesque parturient praesent neque sollicitudin pellentesque vestibulum suspendisse consectetuer leo quisque phasellus pede vestibulum quam pellentesque sollicitudin quis mus adipiscing parturient pellentesque vestibulum",
                           Content = longLoremIpsum
                       };
            item.SetImage(BaseUri, "SampleData/Images/60Strawberry.png");
            Collection.Add(item);

            item = new Item
                       {
                           Title = "Italian Rainbow",
                           Subtitle =
                               "Leo mus nec nascetur dapibus non fames per felis ipsum pharetra egestas montes elit nostra placerat euismod enim justo ornare feugiat platea pulvinar sed sagittis",
                           Link = "http://www.alpineskihouse.com/",
                           Category = "Gelato",
                           Description =
                               "Consequat condimentum consectetuer vivamus urna vestibulum netus pellentesque cras nec taciti non scelerisque adipiscing parturient tellus sollicitudin per vestibulum pellentesque aliquam convallis ullamcorper nulla porta aliquet accumsan suspendisse duis bibendum nunc condimentum consectetuer pellentesque scelerisque tempor sed dictumst eleifend amet vestibulum sem tempus facilisi ullamcorper adipiscing tortor ante purus parturient sit dignissim vel nam turpis sed sollicitudin elementum arcu vestibulum risus blandit suspendisse faucibus pellentesque commodo dis condimentum consectetuer varius aenean conubia cubilia facilisis velit mauris nullam aptent dapibus habitant",
                           Content = longLoremIpsum
                       };
            item.SetImage(BaseUri, "SampleData/Images/60SprinklesRainbow.png");
            Collection.Add(item);

            item = new Item
                       {
                           Title = "Straweberry",
                           Subtitle =
                               "Ultrices rutrum sapien vehicula semper lorem volutpat sociis sit maecenas praesent taciti magna nunc odio orci vel tellus nam sed accumsan iaculis dis est",
                           Link = "http://www.blueyonderairlines.com/",
                           Category = "Ice Cream",
                           Description =
                               "Consectetuer lacinia vestibulum tristique sit adipiscing laoreet fusce nibh suspendisse natoque placerat pulvinar ultricies condimentum scelerisque nisi ullamcorper nisl parturient vel suspendisse nam venenatis nunc lorem sed dis sagittis pellentesque luctus sollicitudin morbi posuere vestibulum potenti magnis pellentesque vulputate mattis mauris mollis consectetuer pellentesque pretium montes vestibulum condimentum nulla adipiscing sollicitudin scelerisque ullamcorper pellentesque odio orci rhoncus pede sodales suspendisse parturient viverra curabitur proin aliquam integer augue quam condimentum quisque senectus quis urna scelerisque nostra phasellus ullamcorper cras duis suspendisse sociosqu dolor vestibulum condimentum consectetuer vivamus est fames felis suscipit hac",
                           Content = longLoremIpsum
                       };
            item.SetImage(BaseUri, "SampleData/Images/60Strawberry.png");
            Collection.Add(item);

            item = new Item
                       {
                           Title = "Strawberry Frozen Yogurt",
                           Subtitle =
                               "Maecenas class nam praesent cras aenean mauris aliquam nullam aptent accumsan duis nunc curae donec integer auctor sed congue amet",
                           Link = "http://www.adatum.com/",
                           Category = "Low-fat frozen yogurt",
                           Description =
                               "Curabitur class aliquam vestibulum nam curae maecenas sed integer cras phasellus suspendisse quisque donec dis praesent accumsan bibendum pellentesque condimentum adipiscing etiam consequat vivamus dictumst aliquam duis convallis scelerisque est parturient ullamcorper aliquet fusce suspendisse nunc hac eleifend amet blandit facilisi condimentum commodo scelerisque faucibus aenean ullamcorper ante mauris dignissim consectetuer nullam lorem vestibulum habitant conubia elementum pellentesque morbi facilisis arcu sollicitudin diam cubilia aptent vestibulum auctor eget dapibus pellentesque inceptos leo egestas interdum nulla consectetuer suspendisse adipiscing pellentesque proin lobortis sollicitudin augue elit mus congue fermentum parturient fringilla euismod feugiat",
                           Content = longLoremIpsum
                       };
            item.SetImage(BaseUri, "SampleData/Images/60Strawberry.png");
            Collection.Add(item);

            item = new Item
                       {
                           Title = "Bongo Banana",
                           Subtitle =
                               "Quisque vivamus bibendum cursus dictum dictumst dis aliquam aliquet etiam lectus eleifend fusce libero ante facilisi ligula est",
                           Link = "http://www.adventure-works.com/",
                           Category = "Sorbet",
                           Description =
                               "Enim cursus nascetur dictum habitasse hendrerit nec gravida vestibulum pellentesque vestibulum adipiscing iaculis erat consectetuer pellentesque parturient lacinia himenaeos pharetra condimentum non sollicitudin eros dolor vestibulum per lectus pellentesque nibh imperdiet laoreet consectetuer placerat libero malesuada pellentesque fames penatibus ligula scelerisque litora nisi luctus vestibulum nisl ullamcorper sed sem natoque suspendisse felis sit condimentum pulvinar nunc posuere magnis vel scelerisque sagittis porttitor potenti tincidunt mattis ipsum adipiscing sollicitudin parturient mauris nam senectus ullamcorper mollis tristique sociosqu suspendisse ultricies montes sed condimentum dis nostra suscipit justo ornare pretium odio pellentesque lacus lorem torquent orci",
                           Content = longLoremIpsum
                       };
            item.SetImage(BaseUri, "SampleData/Images/60Banana.png");
            Collection.Add(item);

            item = new Item
                       {
                           Title = "Firenze Vanilla",
                           Subtitle =
                               "Litora luctus magnis arcu lorem morbi blandit faucibus mattis commodo hac habitant inceptos conubia cubilia nulla mauris diam proin augue eget dolor mollis interdum lobortis",
                           Link = "http://www.adventure-works.com/",
                           Category = "Gelato",
                           Description =
                               "Vestibulum vestibulum magna scelerisque ultrices consectetuer vehicula rhoncus pellentesque massa adipiscing platea primis sodales parturient metus sollicitudin morbi vestibulum pellentesque consectetuer pellentesque volutpat rutrum sollicitudin sapien pellentesque vestibulum venenatis consectetuer viverra est aliquam semper hac maecenas integer adipiscing sociis vulputate ullamcorper curabitur pellentesque parturient praesent neque sollicitudin pellentesque vestibulum suspendisse consectetuer leo quisque phasellus pede vestibulum quam pellentesque sollicitudin quis mus adipiscing parturient pellentesque vestibulum",
                           Content = longLoremIpsum
                       };
            item.SetImage(BaseUri, "SampleData/Images/60Vanilla.png");
            Collection.Add(item);

            item = new Item
                       {
                           Title = "Choco-wocko",
                           Subtitle =
                               "Leo mus nec nascetur dapibus non fames per felis ipsum pharetra egestas montes elit nostra placerat euismod enim justo ornare feugiat platea pulvinar sed sagittis",
                           Link = "http://www.alpineskihouse.com/",
                           Category = "Sorbet",
                           Description =
                               "Consequat condimentum consectetuer vivamus urna vestibulum netus pellentesque cras nec taciti non scelerisque adipiscing parturient tellus sollicitudin per vestibulum pellentesque aliquam convallis ullamcorper nulla porta aliquet accumsan suspendisse duis bibendum nunc condimentum consectetuer pellentesque scelerisque tempor sed dictumst eleifend amet vestibulum sem tempus facilisi ullamcorper adipiscing tortor ante purus parturient sit dignissim vel nam turpis sed sollicitudin elementum arcu vestibulum risus blandit suspendisse faucibus pellentesque commodo dis condimentum consectetuer varius aenean conubia cubilia facilisis velit mauris nullam aptent dapibus habitant",
                           Content = longLoremIpsum
                       };
            item.SetImage(BaseUri, "SampleData/Images/60SauceChocolate.png");
            Collection.Add(item);

            item = new Item
                       {
                           Title = "Chocolate",
                           Subtitle =
                               "Ultrices rutrum sapien vehicula semper lorem volutpat sociis sit maecenas praesent taciti magna nunc odio orci vel tellus nam sed accumsan iaculis dis est",
                           Link = "http://www.blueyonderairlines.com/",
                           Category = "Ice Cream",
                           Description =
                               "Consectetuer lacinia vestibulum tristique sit adipiscing laoreet fusce nibh suspendisse natoque placerat pulvinar ultricies condimentum scelerisque nisi ullamcorper nisl parturient vel suspendisse nam venenatis nunc lorem sed dis sagittis pellentesque luctus sollicitudin morbi posuere vestibulum potenti magnis pellentesque vulputate mattis mauris mollis consectetuer pellentesque pretium montes vestibulum condimentum nulla adipiscing sollicitudin scelerisque ullamcorper pellentesque odio orci rhoncus pede sodales suspendisse parturient viverra curabitur proin aliquam integer augue quam condimentum quisque senectus quis urna scelerisque nostra phasellus ullamcorper cras duis suspendisse sociosqu dolor vestibulum condimentum consectetuer vivamus est fames felis suscipit hac",
                           Content = longLoremIpsum
                       };
            item.SetImage(BaseUri, "SampleData/Images/60SauceChocolate.png");
            Collection.Add(item);
        }

        /// <summary>
        /// Gets the collection.
        /// </summary>
        public ItemCollection Collection
        {
            get
            {
                return _collection;
            }
        }

        /// <summary>
        /// The method returns the list of groups, each containing a key and a list of items. 
        /// The key of each group is the category of the item. 
        /// </summary>
        /// <returns>
        /// The List of groups of items. 
        /// </returns>
        internal ObservableCollection<GroupInfoCollection<Item>> GetGroupsByCategory()
        {
            ObservableCollection<GroupInfoCollection<Item>> groups = new ObservableCollection<GroupInfoCollection<Item>>();

            var query = from item in Collection
                        orderby item.Category
                        group item by item.Category into g
                        select new { GroupName = g.Key, Items = g };

            foreach (var g in query)
            {
                GroupInfoCollection<Item> info = new GroupInfoCollection<Item>
                                                 {
                                                     Key = g.GroupName
                                                 };
                foreach (Item item in g.Items)
                {
                    info.Add(item);                    
                }

                groups.Add(info);
            }

            return groups;
        }
    }
}
