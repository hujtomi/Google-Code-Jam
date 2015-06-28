public class TypoCoderDiv2 {

	public int count(int[] rating) {
		boolean brownCoder = true;

		int counter = 0;

		for (int i = 0; i < rating.length; i++) {

			if (brownCoder) {
				if (rating[i] >= 1200) {
					counter++;
					brownCoder = false;
				}
			} else if (!brownCoder) {
				if(rating[i] < 1200)
				{
					counter++;
					brownCoder = true;
				}
			}

		}

		return counter;
	}

}
