using GameBot1.Action;
using GameBot1.Action.AuctionHouse.At;
using GameBot1.Action.AuctionHouse.In;
using GameBot1.Action.AuctionHouse.In.Repeatable;
using GameBot1.Action.AuctionHouse.InSlot;
using GameBot1.Action.Crops;
using GameBot1.Action.Crops.Seed;
using GameBot1.Action.Navigation;
using GameBot1.Action.Rescue;

namespace GameBot1
{
    class CropCycleConfiguration
    {
        internal Action.Action GenerateSeedHarvestAndSell()
        {
            MasterNavigationAction a = new MasterNavigationAction()
                .Add(new GotoCrops()
                    .Add(new HarvestAllCrops()
                        .Add(new SeedWheet())))
                .Add(new GotoHomePosition(2))
                .Add(new GotoAuctionHouse()
                    .Add(new OpenAuctionHouse()
                        .Add(new GotLastPage())
                        .Add(new SearchAndCollectCoins())
                        .Add(new SearchUnSoldSlotAndPostAdd())
                        .Add(new SearchAndOpenEmptySlot()
                            .Add(new PostWheet()))
                        .Add(new GotoNextPage(2)
                            .Add(new SearchAndCollectCoins())
                            .Add(new SearchAndOpenEmptySlot()
                                .Add(new PostWheet())))
                        .Add(new CloseAuctionHouse())))
                .Add(new GotoHomePosition(2));
            return a;
        }

        internal Action.Action GenerateGoHome()
        {
            MasterNavigationAction a = new MasterNavigationAction()
                    .Add(new WaitForHayDayWindowToActivate())
                    .Add(new GotoHomePosition(5));
            return a;
        }

        internal Action.Action GetRescueInvalidState()
        {
            MasterRescueAction a = new MasterRescueAction(1, 600)
                .Add(new OpenAndCloseStatPage())
                .Add(new MasterNavigationAction()
                    .Add(new WaitForHayDayWindowToActivate())
                    .Add(new GotoHomePosition(5)));

            return a;
        }
    }
}
