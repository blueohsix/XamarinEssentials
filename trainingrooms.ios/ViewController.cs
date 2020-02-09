using Foundation;
using System;
using UIKit;

namespace trainingrooms.ios
{
    public partial class ViewController : UITableViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            var repo = new TrainingRooms.RoomRepository();
            var rooms = repo.GetRooms();

            var source = new RoomsDataSource(rooms);
            this.TableView.Source = source;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            RoomsDataSource source = this.TableView.Source as RoomsDataSource;
            var room = source.GetItem(this.TableView.IndexPathForSelectedRow.Row);
            if(segue.Identifier == "detailSegue")
            {
                var target = segue.DestinationViewController as RoomDetailViewController;
                target.SetTrainingRoom(room);
            }
        }
    }
}