using System;
using System.Collections.Generic;
using System.Text;
using Saaspose.Common;
using Saaspose.Storage;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml;


namespace Saaspose.Pdf
{
    /// <summary>
    /// Deals with Annotations, Bookmarks, Attachments and Links in PDF document
    /// </summary>

    public class AnnotationEditor
    {
        public AnnotationEditor(string fileName)
        {
            FileName = fileName;
        }

        /// <summary>
        /// PDF document name
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Gets number of annotations on a specified document page
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <returns>returns number of annotations on a specified page</returns>

        public int GetAnnotationsCount(int pageNumber)
        {
            //build URI to get page count
            string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/pages/" + pageNumber + "/annotations";
            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();


            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);


            //Deserializes the JSON to a object. 
            AnnotationsResponse annotationsResponse = JsonConvert.DeserializeObject<AnnotationsResponse>(parsedJSON.ToString());

            int count = annotationsResponse.Annotations.List.Count;

            return count;
        }


        /// <summary>
        /// Gets list of all the annotations on a specified document page
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <returns>List of annotations on a page</returns>

        public List<Annotation> GetAllAnnotations(int pageNumber)
        {
            List<Annotation> ListAnnotations = new List<Annotation>();
            int iTotalAnnotation=GetAnnotationsCount(pageNumber);
            for (int index = 1; index <= iTotalAnnotation; index++)
            {
                ListAnnotations.Add(GetAnnotation(pageNumber, index));
            }
            return ListAnnotations;

        }

        /// <summary>
        /// Gets a specfied annotation on a specified document page
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="annotationIndex"></param>
        /// <returns>Selected annotation on a page</returns>

        public Annotation GetAnnotation(int pageNumber, int annotationIndex)
        {
               //build URI to get page count
                string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/pages/" + pageNumber + "/annotations/" + annotationIndex;
                string signedURI = Utils.Sign(strURI);

                Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

                StreamReader reader = new StreamReader(responseStream);
                string strJSON = reader.ReadToEnd();


                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);

                //Deserializes the JSON to a object. 
                AnnotationResponse annotationsResponse = JsonConvert.DeserializeObject<AnnotationResponse>(parsedJSON.ToString());


                return annotationsResponse.Annotation;

        }

        /// <summary>
        /// Gets total number of Bookmarks in a Pdf document
        /// </summary>
        /// <returns>Total number of Bookmarks</returns>

        public int GetBookmarksCount()
        {
            //build URI to get page count
            string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/bookmarks/";
            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();


            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);


            //Deserializes the JSON to a object. 
            BookmarksResponse annotationsResponse = JsonConvert.DeserializeObject<BookmarksResponse>(parsedJSON.ToString());

            int count = annotationsResponse.Bookmarks.List.Count;


            return count;
        }

        /// <summary>
        /// Gets number of child bookmarks in a specfied parent bookmark
        /// </summary>
        /// <param name="iParent"></param>
        /// <returns>Toatl number of child bookmarks in a specific parent bookmark</returns>

        public int GetChildBookmarksCount(int iParent)
        {
            //build URI to get page count
            string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/bookmarks/" + iParent + "/bookmarks";
            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();


            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);


            //Deserializes the JSON to a object. 
            BookmarksResponse annotationsResponse = JsonConvert.DeserializeObject<BookmarksResponse>(parsedJSON.ToString());

            int count = annotationsResponse.Bookmarks.List.Count;


            return count;
        }


        /// <summary>
        /// Gets list of all the Bookmarks in a Pdf document
        /// </summary>
        /// <param name="getChildBookmarks"></param>
        /// <returns>List of all the Bookmarks in Pdf document</returns>
        
        public List<Bookmark> GetAllBookmarks(bool getChildBookmarks)
        {
            List<Bookmark> ListBookmarks = new List<Bookmark>();

            Bookmark bookmark = new Bookmark();
            int iTotalBookmarks = GetBookmarksCount();
            int [] ChildNum=new int[ iTotalBookmarks];
            int temChildCount = 0;
            int iTotalParent = iTotalBookmarks;
            int iTotalChild = 0;
        
            for (int iTem = 1; iTem <= iTotalParent; iTem++)
            {
                temChildCount = GetChildBookmarksCount(iTem);
                if(temChildCount >0)
                {
                    iTotalParent -= temChildCount;
                    iTotalChild+=temChildCount;
                    ChildNum[iTem] = temChildCount;
                }
            }

            for (int index = 1; index <= iTotalParent; index++)
             {
                try
                {
                    ListBookmarks.Add(GetBookmark(index));
                }
                catch (Exception ex)
                {
                    //throw new Exception(ex.Message);
                }
                
            }

            if (getChildBookmarks)
            {
                for(int iParent=1;iParent<=iTotalParent;iParent++)
                {
                    for (int iChild = 1; iChild <= ChildNum[iParent]; iChild++)
                    {
                        try
                        {
                            ListBookmarks.Add(GetChildBookmark(iParent, iChild));
                        }
                        catch (Exception ex)
                        {
                            //throw new Exception(ex.Message);
                        }
                    
                    }
                
                }

            }
            return ListBookmarks;


        }

        /// <summary>
        /// Gets a specfied Bookmark in a specified document page
        /// </summary>
        /// <param name="bookmarkIndex"></param>
        /// <returns>Selected Bookmark</returns>
        
        public Bookmark GetBookmark(int bookmarkIndex)
        {
            //build URI to get page count
            string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/bookmarks/" + bookmarkIndex; 


            string signedURI = Utils.Sign(strURI);
            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();


            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            BookmarkResponse bookmarkResponse = JsonConvert.DeserializeObject<BookmarkResponse>(parsedJSON.ToString());


            return bookmarkResponse.Bookmark;
          
        }

        /// <summary>
        /// Gets a specfied child Bookmark for selected parent bookmark in Pdf document
        /// </summary>
        /// <param name="parentBookmarkIndex"></param>
        /// <param name="childBookmarkIndex"></param>
        /// <returns>Selected child Bookmark</returns>
 
        public Bookmark GetChildBookmark(int parentBookmarkIndex, int childBookmarkIndex)
        {
            try
            { //build URI to get page count

                string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/bookmarks/" + parentBookmarkIndex + "/bookmarks/" + childBookmarkIndex;


                string signedURI = Utils.Sign(strURI);
                Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

                StreamReader reader = new StreamReader(responseStream);
                string strJSON = reader.ReadToEnd();


                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);

                //Deserializes the JSON to a object. 
                BookmarkResponse bookmarkResponse = JsonConvert.DeserializeObject<BookmarkResponse>(parsedJSON.ToString());


                return bookmarkResponse.Bookmark;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Checks whether selected bookmark is parent or child Gets a specfied child Bookmark for selected parent bookmark in Pdf document
        /// </summary>
        /// <param name="bookmarkIndex"></param>
        /// <returns>True if child bookmark; false otherwise</returns>

        public bool IsChildBookmark(int bookmarkIndex)
        {
            try
            { //build URI to get page count

                string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/bookmarks/" + bookmarkIndex ;


                string signedURI = Utils.Sign(strURI);
                Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

                StreamReader reader = new StreamReader(responseStream);
                string strJSON = reader.ReadToEnd();


                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);

                //Deserializes the JSON to a object. 
                BookmarkResponse bookmarkResponse = JsonConvert.DeserializeObject<BookmarkResponse>(parsedJSON.ToString());


                return false;
            }
            catch (Exception ex)
            {

                return true;
            }
        }

        /// <summary>
        /// Gets number of attachments in the Pdf document
        /// </summary>
        /// <returns>Number of attachments in Pdf document</returns>

        public int GetAttachmentsCount()
        {
            //build URI to get page count
            string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/attachments";
            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();


            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);


            //Deserializes the JSON to a object. 
            AttachmentsResponse attachmentsResponse = JsonConvert.DeserializeObject<AttachmentsResponse>(parsedJSON.ToString());

            int count = attachmentsResponse.Attachments .List.Count;


            return count;
        }


        /// <summary>
        /// Gets List of all the attachments in Pdf document
        /// </summary>
        /// <returns>List of attachments in a Pdf document</returns>

        public List<Attachment> GetAllAttachments()
        {
            List<Attachment> ListAttachments = new List<Attachment>();
            int iTotalAttachments = GetAttachmentsCount();
            for (int index = 1; index <= iTotalAttachments; index++)
            {

                ListAttachments.Add(GetAttachment(index));
            }
            return ListAttachments;

        }
        
        /// <summary>
        /// Gets selected attachment from Pdf document
        /// </summary>
        /// <param name="attachmentIndex"></param>
        /// <returns>Selected attachment at specfied index</returns>
        
        public Attachment GetAttachment(int attachmentIndex)
        {
            //build URI to get page count
            string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/attachments/" + attachmentIndex;
            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();


            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            AttachmentResponse attachmentResponse = JsonConvert.DeserializeObject<AttachmentResponse>(parsedJSON.ToString());


            return attachmentResponse.Attachment;

        }

        /// <summary>
        /// Download the selected attachment from Pdf document
        /// </summary>
        /// <param name="outputPath"></param>
        /// <param name="attachmentIndex"></param>
        /// <returns>Saves the selected attchment on specified output path</returns>

        public void DownloadAttachment(string outputPath, int attachmentIndex)
        {
            Attachment  FileInformation = GetAttachment(attachmentIndex);

            //build URI to get page count
            string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/attachments/" + attachmentIndex+"/download";
            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            using (Stream fileStream = System.IO.File.OpenWrite(outputPath + "\\" + FileInformation.Name))
            {
                Utils.CopyStream(responseStream, fileStream);
            }
            responseStream.Close();

        }

        /// <summary>
        /// Get number of links in Pdf document page
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <returns>Get total number of links in a page</returns>

        public int GetLinksCount(int pageNumber)
        {
            //build URI to get page count
  
            string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/pages/" + pageNumber+"/links";
            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();


            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);


            //Deserializes the JSON to a object. 
            PdfLinksResponse pdfLinksResponse = JsonConvert.DeserializeObject<PdfLinksResponse>(parsedJSON.ToString());

            int count = pdfLinksResponse.Links.List.Count;


            return count;
        }


        /// <summary>
        /// Gets list of all links in a Pdf document page
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <returns>List of links on a page</returns>

        public List<Link> GetAllLinks(int pageNumber)
        {
            List<Link> ListLinks = new List<Link>();
            int iTotalLinks = GetLinksCount(pageNumber);
            for (int index = 1; index <= iTotalLinks; index++)
            {

                ListLinks.Add(GetLink(pageNumber,index));
            }
            return ListLinks;

        }
        

        /// <summary>
        /// Gets selected link in a in a Pdf document page
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="attachmentIndex"></param>
        /// <returns>Selected link at a specified index in a specified Pdf document page</returns>

        public Link GetLink(int pageNumber, int attachmentIndex)
        {
            //build URI to get page count
            string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/pages/" + pageNumber + "/links/"+attachmentIndex;
            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();


            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            PdfLinkResponse pdfLinkResponse = JsonConvert.DeserializeObject<PdfLinkResponse>(parsedJSON.ToString());

         //   return pdfLinkResponse;
          return pdfLinkResponse.Link;

        }

    }

}
