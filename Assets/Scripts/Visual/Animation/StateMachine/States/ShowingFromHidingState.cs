using UnityEditor.Experimental.GraphView;

namespace StarsProject.Visual.Animation.States
{
    public class ShowingFromHidingState : AnimationState
    {
        public override AnimationStateType Type => AnimationStateType.ShowingFromHiding;
        
        private int appearingLinesCount;
        
        public ShowingFromHidingState(PreviewAnimation previewAnimation, StarLineAnimationsSet[] starLineAnimSets,
            IndexContainer indexContainer) : base(previewAnimation, starLineAnimSets, indexContainer)
        { }

        public override void OnEnter()
        {
            for (var i = 0; i < indexContainer.Value; i++)
            {
                appearingLinesCount += starLineAnimSets[i].AnimationsCount;
                starLineAnimSets[i].Show(finishedCallback: OnLinesAppeared);
            }
        }

        private void OnLinesAppeared()
        {
            appearingLinesCount -= 1;

            if (appearingLinesCount != 0)
            {
                return;
            }
            
            RaiseChangeState(AnimationStateType.ShowingFromStart);
        }

        public override void Update()
        {
            for (var i = 0; i < indexContainer.Value; i++)
            {
                starLineAnimSets[i].UpdateSelf();
            }
        }

        public override void WantsToHide()
        {
            RaiseChangeState(AnimationStateType.Hiding);
        }
    }
}